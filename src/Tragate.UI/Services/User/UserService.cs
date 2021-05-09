using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

namespace Tragate.UI.Services
{
    public class UserService : IUserService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public UserService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public UserResponse GetUser(int id)
        {
            return _restClient.Get<UserResponse>(string.Format($"{_settings.ApiUrl}/{API.User.GetUser}", id));
        }

        public BaseResponse UpdateUser(UserProfileViewModel model)
        {
            return _restClient.Put<UserResponse>(
                string.Format($"{_settings.ApiUrl}/{API.User.UpdateUser}", model.UserId), model);
        }

        public BaseResponse ChangePassword(int id, ChangePasswordViewModel model)
        {
            return _restClient.Patch<UserResponse>($"{_settings.ApiUrl}/{string.Format(API.User.ChangePassword, id)}",
                model);
        }

        public BaseResponse UploadProfileImage(IFormFile files, int id)
        {
            return _restClient.PostMultipartContent<BaseResponse>(
                string.Format($"{_settings.ApiUrl}/{API.User.ChangeProfileImage}", id), files);
        }

        public UserDashboardResponse GetUserDashboardInfo(int id)
        {
            return _restClient.Get<UserDashboardResponse>(
                string.Format($"{_settings.ApiUrl}/{API.User.GetUserDashboardInfo}", id));
        }

        public BaseResponse ChangeEmail(int id, ChangeEmailViewModel model)
        {
            var result =
                _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.User.ChangeEmail, id)}", model);
            return result;
        }

        public UserTodoListResponse GetUserTodoListById(int id)
        {
            return _restClient.Get<UserTodoListResponse>(string.Format($"{_settings.ApiUrl}/{API.User.GetUserTodoList}",
                id));
        }

        public QuotationResponseMessage GetUserBuyerQuotationList(int userId, int page, int pageSize,
            int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            if (quoteStatusId.HasValue)
            {
                sb.Append($"?quoteStatus={quoteStatusId}");
            }

            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }

            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.User.GetUserBuyerQuotationList, userId, page, pageSize, sb.ToString())}");
            return response;
        }

        public QuotationResponseMessage GetUserSellerQuotationList(int userId, int page, int pageSize,
            int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            if (quoteStatusId.HasValue)
            {
                sb.Append($"?quoteStatus={quoteStatusId}");
            }

            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }

            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.User.GetUserSellerQuotationList, userId, page, pageSize, sb.ToString())}");
            return response;
        }

        public UserQuoteNotificationResponse GetUserQuoteNotificationById(int userId)
        {
            return _restClient.Get<UserQuoteNotificationResponse>(
                $"{_settings.ApiUrl}/{string.Format(API.User.GetUserQuoteNotification, userId)}");
        }

        public BaseResponse SendEmailVerify(SendEmailVerifyViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.User.SendActivationEmail}", model);
        }
    }
}