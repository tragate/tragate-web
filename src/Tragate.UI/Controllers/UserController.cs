using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.User;
using Tragate.UI.Services;
using Tragate.UI.Services.Quote;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    public class UserController : Controller
    {
        private readonly ICompanyAdminService _companyAdminService;
        private readonly IUserService _userService;
        private readonly IApplicationUser _applicationUser;
        private readonly IMapper _mapper;
        private readonly IQuotationService _quotationService;

        public UserController(ICompanyAdminService companyAdminService,
            IUserService userService,
            IApplicationUser applicationUser,
            IMapper mapper, IQuotationService quotationService)
        {
            _companyAdminService = companyAdminService;
            _userService = userService;
            _applicationUser = applicationUser;
            _mapper = mapper;
            _quotationService = quotationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _userService.GetUserDashboardInfo(_applicationUser.UserId);
            var company =
                _companyAdminService.GetCompanyAdminsByUserId(1, 3, _applicationUser.UserId, (int)StatusType.Active);

            var vm = _mapper.Map<UserDashboardViewModel>(result.UserDashboardInfo);
            vm.UserCompanyList = company.CompanyAdminListResponse.CompanyAdminList;

            var todoListResponse = _userService.GetUserTodoListById(_applicationUser.UserId);
            if (todoListResponse.Success)
                vm.UserTodoList = todoListResponse.UserTodos;

            return View(vm);
        }

        [HttpPost]
        [Route("user/image-upload/{id:int}")]
        public IActionResult ChangeProfileImage(IFormFile files, int id)
        {
            var result = _userService.UploadProfileImage(files, id);
            if (result.Success)
            {
                return Json(result);
            }
            else
            {
                string errorString = string.Join(",", result.ErrorList);
                throw new InvalidOperationException(errorString);
            }
        }

        [HttpGet("user/changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // [HttpGet ("user/user-image/{id:int}")]
        // public IActionResult GetUserImage (int id) {
        //    var model = _userService.GetUser(id);

        //     if (model == null) {
        //         return NotFound ();
        //     }

        //     var vm = _mapper.Map<UserViewModel> (model.User);
        //     return Json (vm.ProfileImagePath);
        // }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.ChangePassword(_applicationUser.UserId, model);
                if (result.Success)
                {
                    return Redirect("/user/settings");
                }
                else
                {
                    ViewBag.Errors = result.ErrorList;
                }
            }

            return View();
        }

        [HttpGet("user/company")]
        public IActionResult Company([FromQuery] int page = 1)
        {
            var result =
                _companyAdminService.GetCompanyAdminsByUserId(page, 10, _applicationUser.UserId,
                    (int)StatusType.Active);
            if (result.Success)
            {
                var model = _mapper.Map<CompanyAdminListViewModel>(result.CompanyAdminListResponse);
                return View(model);
            }

            return View();
        }

        [HttpGet("user/settings")]
        public IActionResult Settings()
        {
            var result = _userService.GetUser(_applicationUser.UserId);
            if (result.Success)
            {
                var vm = _mapper.Map<UserProfileViewModel>(result.User);
                return View(vm);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _userService.GetUser(_applicationUser.UserId);
            if (result.Success)
            {
                var vm = _mapper.Map<UserProfileViewModel>(result.User);
                return View(vm);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LocationId = model.StateId;
                var result = _userService.UpdateUser(model);
                if (result.Success)
                {
                    return Redirect("/user/settings");
                }
            }

            return View();
        }

        [HttpGet("user/changeemail")]
        public IActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeEmail(ChangeEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.ChangeEmail(_applicationUser.UserId, model);
                if (result.Success)
                {
                    return Redirect("/user/SendVerifyEmail");
                }
                else
                {
                    ViewBag.Errors = result.ErrorList;
                }
            }

            return View();
        }

        public IActionResult SendVerifyEmail()
        {
            SendEmailVerifyViewModel model = new SendEmailVerifyViewModel()
            {
                Email = _applicationUser.Email
            };

            var result = _userService.SendEmailVerify(model);
            if (result.Success)
            {
                return Redirect("/user/verificationEmailSent");
            }
            return Redirect("/user");
        }

        public IActionResult VerificationEmailSent()
        {
            return View();
        }

        [HttpPost]
        [Route("user/getbuyer-quotes")]
        public JsonResult GetBuyerQuotes(int quoteStatusId, int page = 1)
        {
            return Json(ReturnBuyerQuotation(quoteStatusId, page));
        }

        [Route("user/buyer-quotes")]
        public IActionResult BuyerQuotes()
        {
            return View();
        }

        private QuotationUserBuyerListViewModel ReturnBuyerQuotation(int quoteStatusId, int page = 1)
        {
            var result = _userService.GetUserBuyerQuotationList(_applicationUser.UserId, page, 10, quoteStatusId, null);

            var model = new QuotationUserBuyerListViewModel()
            {
                PageNumber = page,
                PageSize = result.QuotationResponse.PageSize,
                TotalCount = result.QuotationResponse.TotalCount,
                QuotationUserBuyerList = _mapper.Map<List<QuotationUserBuyerViewModel>>(result.QuotationResponse.QuotationList),
                QuoteStatusId = quoteStatusId,
                TotalPage = (int)Math.Ceiling(((double)result.QuotationResponse.TotalCount / (double)result.QuotationResponse.PageSize))
            };
            return model;
        }

        [HttpPost]
        [Route("user/getseller-quotes")]
        public JsonResult GetSellerQuotes(int quoteStatusId, int page = 1)
        {
            return Json(ReturnSellerQuotation(quoteStatusId, page));
        }

        [Route("user/seller-quotes")]
        public IActionResult SellerQuotes()
        {
            return View();
        }

        private QuotationUserSellerListViewModel ReturnSellerQuotation(int quoteStatusId, int page = 1)
        {
            var result = _userService.GetUserSellerQuotationList(_applicationUser.UserId, page, 10, quoteStatusId, null);

            var model = new QuotationUserSellerListViewModel()
            {
                PageNumber = page,
                PageSize = result.QuotationResponse.PageSize,
                TotalCount = result.QuotationResponse.TotalCount,
                QuoteStatusId = quoteStatusId,
                QuotationUserSellerList = _mapper.Map<List<QuotationUserSellerViewModel>>(result.QuotationResponse.QuotationList),
                TotalPage = (int)Math.Ceiling(((double)result.QuotationResponse.TotalCount / (double)result.QuotationResponse.PageSize))
            };
            return model;
        }
    }
}