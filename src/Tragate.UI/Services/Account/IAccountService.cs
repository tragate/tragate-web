using System.Threading.Tasks;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

namespace Tragate.UI.Services
{
    public interface IAccountService
    {
        UserResponse Login(LoginViewModel model);
        BaseResponse SignUp(UserRegisterViewModel model);
        BaseResponse Verify(VerifyViewModel model);
        UserResponse GetUserByToken(string token);
        BaseResponse ForgotPassword(ForgotPasswordViewModel model);
        BaseResponse ResetPassword(ResetPasswordViewModel model);
        UserResponse CompleteSignUp(CompleteSignUpViewModel model);
        BaseResponse ExternalSignUp(ExternalSignUpViewModel model);
        UserResponse ExternalLogin(ExternalLoginViewModel model);
    }
}