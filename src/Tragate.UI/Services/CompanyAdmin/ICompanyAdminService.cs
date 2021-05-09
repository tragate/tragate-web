using Microsoft.AspNetCore.Http;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.CompanyAdmin;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Services {
    public interface ICompanyAdminService {
        CompanyAdminListResponseMessage GetCompanyAdminsByUserId (int page, int pageSize, int userId, int? statusId);
        UserCompanyAdminListResponseMessage GetCompanyAdminsByCompanyId (int page, int pageSize, int companyId, int? statusId);
        BaseResponse AddCompanyAdmin (CompanyAdminCreateViewModel model);
        BaseResponse DeleteCompanyAdmin (int id);
        BaseResponse IsAdminOfCompany (int companyId, int loggedUserId);
        CompanyAdminProductResponse GetCompanyAdminProducts(int id,string name,int status, int page, int pageSize);
        CompanyAdminDashboardResponse GetCompanyAdminDashboardInfo(int id);
        BaseResponse UploadProfileImage(IFormFile files, int id);
        CompanyAdminTodoListResponse GetCompanyAdminTodoListById(int id);

        QuotationResponseMessage GetCompanyBuyerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId);
        QuotationResponseMessage GetCompanySellerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId);

    }
}