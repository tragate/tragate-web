using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IApplicationUser _applicationUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public AccountController(
            IAccountService accountService,
            IApplicationUser applicationUser,
            IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _accountService = accountService;
            _applicationUser = applicationUser;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                HttpContext.Session.SetString("returnUrl", returnUrl);

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.PlatformId = (int)PlatformType.Web;
            var result = _accountService.Login(model) ?? new UserResponse
            {
                Success = false,
                Message = "Service not responding in a proper way"
            };

            if (result.Links != null)
            {
                //result.Url = "/account/complete-signup-info";
                result.Url = result.Links.First().Href;
            }

            if (result.Success)
            {
                result = await ClaimAuthentice(result.User);
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public IActionResult Signup(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                TempData["email"] = model.Email;
                model.LocationId = model.StateId.Value;
                model.Email = model.Email.Trim();
                var result = _accountService.SignUp(model);

                if (result == null)
                {
                    result = new BaseResponse();
                    result.Success = false;
                    result.Message = "Service not responding in a proper way";
                }

                if (result.Links != null)
                {
                    //result.Url = "/account/complete-signup-info";
                    result.Url = result.Links.First().Href;
                }

                if (result.Success)
                    result.Message =
                        "Registered successfully. To complete process, click verify link that's been sent to your mail adress. ";

                return Json(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmail(VerifyViewModel model)
        {
            var result = _accountService.Verify(model);

            if (result == null)
            {
                result = new BaseResponse();
                result.Success = false;
            }

            if (result.Success)
            {
                var userResponse = _accountService.GetUserByToken(model.Token);
                if (userResponse.Success)
                {
                    await Login(new LoginViewModel()
                    {
                        Email = userResponse.User.Email,
                        AutoLogin = true,
                        Token = model.Token
                    });
                }

                return Redirect("/account/verified");
            }

            Response.StatusCode = 404;
            return Redirect("/error/404");
        }

        [HttpGet("account/verified")]
        public IActionResult Verified()
        {
            var model = new CompanyViewModel() { PersonId = _applicationUser.UserId };
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUpConfirmation()
        {
            return PartialView();
        }


        //Silinebilir
        //[HttpGet("account/reset")]
        //public IActionResult ResetConfirmation()
        //{
        //    return PartialView();
        //}

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //Silinebilir
        //[HttpGet("account/forgot-password-confirmation")]
        //public IActionResult ForgotPasswordConfirmation()
        //{
        //    return PartialView();
        //}

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            var result = _accountService.ForgotPassword(model);

            if (result == null)
            {
                result = new Models.Response.BaseResponse();
                result.Success = false;
                result.Message = "Service not responding in a proper way";
            }

            if (result.Links != null)
            {
                result.Url = result.Links.First().Href;
            }

            if (result.Success)
            {
                result.Message = "Email has been sent to your email, check your inbox.";
            }

            return Json(result);
        }

        [HttpGet]
        [Route("account/reset-password/{token}")]
        public IActionResult ResetPassword(string token)
        {
            var response = _accountService.GetUserByToken(token);

            if (response == null)
            {
                response = new UserResponse();
                response.Success = false;
            }

            if (response.Success)
            {
                return View(new ResetPasswordViewModel()
                {
                    Token = token,
                    Email = response.User.Email
                });
            }

            Response.StatusCode = 404;
            return Redirect("/error/404");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = _accountService.ResetPassword(model);

            if (result == null)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = "Service not responding in a proper way";
            }

            if (result.Success)
            {
                await Login(new LoginViewModel()
                {
                    AutoLogin = true,
                    Email = model.Email,
                    Token = model.Token
                });
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                _httpContextAccessor.HttpContext.SignOutAsync("TragateIdentity");
            }

            return Redirect("/");
        }

        [HttpGet]
        [Route("account/completeSignup/{token}")]
        public IActionResult CompleteSignUp(string token)
        {
            var result = _accountService.GetUserByToken(token);
            if (result.Success)
            {
                CompleteSignUpViewModel model = new CompleteSignUpViewModel()
                {
                    Token = token,
                    Email = result.User.Email,
                    Location = result.User.Location.Name
                };
                return View(model);
            }

            return Redirect("/");
        }

        [HttpPost]
        [Route("account/complete-sign-up")]
        public async Task<IActionResult> CompleteSignUp(CompleteSignUpViewModel model)
        {
            var result = _accountService.CompleteSignUp(model);

            if (result.Success)
            {
                await Login(new LoginViewModel()
                {
                    Email = model.Email,
                    Token = model.Token,
                    AutoLogin = true,
                });
            }

            result.Url = "/user";
            return Json(result);
        }

        [Route("account/complete-signup-info")]
        public IActionResult CompleteSignUpInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmailVerifyAgain(string email)
        {
            SendEmailVerifyViewModel model = new SendEmailVerifyViewModel()
            {
                Email = email
            };
            var result = _userService.SendEmailVerify(model);
            return Json(result);
            //return Redirect("/");
        }

        [HttpPost]
        [Route("account/external-sign-up")]
        public async Task<JsonResult> ExternalSignUp(ExternalSignUpViewModel model)
        {
            var loginModel = new ExternalLoginViewModel
            {
                ExternalUserId = model.ExternalUserId,
                Email = model.Email
            };

            var loginResult = _accountService.ExternalLogin(loginModel);
            if (loginResult.Success)
            {
                var loginResponse = await ClaimAuthentice(loginResult.User);
                return Json(loginResponse);
            }
            else
            {
                var signUpResult = _accountService.ExternalSignUp(model);
                if (signUpResult.Success)
                {
                    var loginResult2 = _accountService.ExternalLogin(loginModel);
                    if (loginResult2.Success)
                    {
                        var loginResponse2 = await ClaimAuthentice(loginResult2.User);
                        loginResponse2.Url = "/Account/Verified";
                        return Json(loginResponse2);
                    }

                    return Json(loginResult2);
                }

                return Json(signUpResult);
            }
        }

        private async Task<UserResponse> ClaimAuthentice(UserDto model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                new Claim(ClaimTypes.Country, model.Country.Name),
                new Claim("CountryId", model.CountryId.ToString()),
                new Claim("Location", model.Location.Name),
                new Claim("LocationId", model.LocationId.ToString()),
                new Claim(ClaimTypes.StateOrProvince, model.StateId.ToString()),
                new Claim("EmailVerified", model.EmailVerified.ToString())
            };

            // Create the identity from the user info
            var identity = new ClaimsIdentity(claims, "TragateIdentity");

            // Authenticate using the identity
            var principal = new ClaimsPrincipal(identity);
            await _httpContextAccessor.HttpContext.SignInAsync("TragateIdentity", principal);

            var result = new UserResponse();

            result.Success = true;
            result.Message = "Login successful";
            result.Url = _httpContextAccessor.HttpContext.Session.GetString("returnUrl") != null
                ? _httpContextAccessor.HttpContext.Session.GetString("returnUrl")
                : "/user";
            return result;
        }
    }
}