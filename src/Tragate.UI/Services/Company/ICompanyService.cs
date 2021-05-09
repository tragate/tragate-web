using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Company;

namespace Tragate.UI.Services
{
    public interface ICompanyService
    {
        BaseResponse Register(CompanyViewModel model);
        BaseResponse Update(CompanyProfileViewModel model);
        CompanyResponse GetCompanyById(int id);
        CompanyResponse GetCompanyBySlug(string slug);
        CompanyProductResponse GetCompanyProducts(string slug, int? page, int? pageSize);
    }
}