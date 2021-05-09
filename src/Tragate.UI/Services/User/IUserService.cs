using Microsoft.AspNetCore.Http;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

namespace Tragate.UI.Services
{
    public interface IUserService
    {
        UserResponse GetUser(int id);
        BaseResponse UpdateUser(UserProfileViewModel model);
        BaseResponse ChangePassword(int id, ChangePasswordViewModel model);
        BaseResponse UploadProfileImage(IFormFile files, int id);
        UserDashboardResponse GetUserDashboardInfo(int id);
        BaseResponse ChangeEmail(int id, ChangeEmailViewModel model);
        UserTodoListResponse GetUserTodoListById(int id);

        QuotationResponseMessage GetUserBuyerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId);

        QuotationResponseMessage GetUserSellerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId);

        UserQuoteNotificationResponse GetUserQuoteNotificationById(int userId);
        BaseResponse SendEmailVerify(SendEmailVerifyViewModel model);
    }
}