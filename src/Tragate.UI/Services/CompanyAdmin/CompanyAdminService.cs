using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.CompanyAdmin;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Services
{
    public class CompanyAdminService : ICompanyAdminService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public CompanyAdminService(IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public CompanyAdminListResponseMessage GetCompanyAdminsByUserId(int page, int pageSize, int userId, int? statusId = null)
        {
            StringBuilder sb = new StringBuilder();
            if (statusId.HasValue)
                sb.Append($"?status={statusId}");
            return _restClient.Get<CompanyAdminListResponseMessage>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.GetCompanyAdminsByUserId}", userId, page, pageSize, sb.ToString()));
        }

        public UserCompanyAdminListResponseMessage GetCompanyAdminsByCompanyId(int page, int pageSize, int companyId, int? statusId = null)
        {
            StringBuilder sb = new StringBuilder();
            if (statusId.HasValue)
                sb.Append($"?status={statusId}");
            return _restClient.Get<UserCompanyAdminListResponseMessage>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.GetCompanyAdminsByCompanyId}", companyId, page, pageSize, sb.ToString()));
        }

        public BaseResponse IsAdminOfCompany(int companyId, int loggedUserId)
        {
            return _restClient.Get<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.IsAdminOfCompany}", companyId, loggedUserId));
        }

        public BaseResponse AddCompanyAdmin(CompanyAdminCreateViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.CompanyAdmin.CreateCompanyAdmin}", model);
        }

        public BaseResponse DeleteCompanyAdmin(int id)
        {
            return _restClient.Delete<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.DeleteCompanyAdmin}", id));
        }

        public CompanyAdminProductResponse GetCompanyAdminProducts(int id, string name, int status, int page, int pageSize)
        {
            var queryString = new StringBuilder();
            queryString.Append($"?status={status}");
            if (!string.IsNullOrEmpty(name))
                queryString.Append($"&name={name}");

            return _restClient.Get<CompanyAdminProductResponse>
                 (string.Format($"{_settings.ApiUrl}/{API.Company.GetCompanyProducts}", id, page, pageSize, queryString.ToString()));
        }

        public CompanyAdminDashboardResponse GetCompanyAdminDashboardInfo(int id)
        {
            return _restClient.Get<CompanyAdminDashboardResponse>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.GetCompanyAdminDashboardInfo}", id));
        }

        public BaseResponse UploadProfileImage(IFormFile files, int id)
        {
            return _restClient.PostMultipartContent<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.UploadProfileImage}", id), files);
        }

        public CompanyAdminTodoListResponse GetCompanyAdminTodoListById(int id)
        {
            return _restClient.Get<CompanyAdminTodoListResponse>(string.Format($"{_settings.ApiUrl}/{API.CompanyAdmin.GetCompanyAdminTodoList}", id));
        }

        public QuotationResponseMessage GetCompanyBuyerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
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
            var response = _restClient.Get<QuotationResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyBuyerQuotationList, companyId, page, pageSize, sb.ToString())}");
            return response;
        }

        public QuotationResponseMessage GetCompanySellerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
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
            var response = _restClient.Get<QuotationResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanySellerQuotationList, companyId, page, pageSize, sb.ToString())}");
            return response;
        }
    }
}