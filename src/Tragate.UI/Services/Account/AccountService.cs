using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

namespace Tragate.UI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public AccountService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public UserResponse Login(LoginViewModel model)
        {
            return _restClient.Post<UserResponse>($"{_settings.ApiUrl}/{API.Account.Login}", model);
        }

        public BaseResponse SignUp(UserRegisterViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Account.SignUp}", model);
        }

        public BaseResponse Verify(VerifyViewModel model)
        {
            var result = _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Account.Verify}", model);
            return result;
        }

        public UserResponse GetUserByToken(string token)
        {
            return _restClient.Get<UserResponse>(string.Format($"{_settings.ApiUrl}/{API.Account.VerifiedUser}",
                token));
        }

        public BaseResponse ForgotPassword(ForgotPasswordViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Account.ForgotPassword}", model);
        }

        public BaseResponse ResetPassword(ResetPasswordViewModel model)
        {
            var result = _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Account.ResetPassword}", model);
            return result;
        }

        public UserResponse CompleteSignUp(CompleteSignUpViewModel model)
        {
            return _restClient.Post<UserResponse>($"{_settings.ApiUrl}/{API.Account.CompleteSignUp}", model);
        }

        public BaseResponse ExternalSignUp(ExternalSignUpViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Account.ExternalSignUp}", model);
        }

        public UserResponse ExternalLogin(ExternalLoginViewModel model)
        {
            return _restClient.Post<UserResponse>($"{_settings.ApiUrl}/{API.Account.ExternalLogin}", model);
        }
    }
}