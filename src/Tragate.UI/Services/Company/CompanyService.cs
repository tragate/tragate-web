using System.Text;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Models.Response.CompanyAdmin;

namespace Tragate.UI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public CompanyService(IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public BaseResponse Register(CompanyViewModel model)
        {
            return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Company.Register}", model);
        }

        public BaseResponse Update(CompanyProfileViewModel model)
        {
            return _restClient.Put<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.Update,model.CompanyId)}", model);
        }

        public CompanyResponse GetCompanyById(int id)
        {
            return _restClient.Get<CompanyResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.GetCompanyById}", id));
        }

        public CompanyResponse GetCompanyBySlug(string slug)
        {
            return _restClient.Get<CompanyResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.GetCompanyBySlug}", slug));
        }

        public CompanyProductResponse GetCompanyProducts(string slug, int? page, int? pageSize)
        {
            return _restClient.Get<CompanyProductResponse>(string.Format($"{_settings.ApiUrl}/{API.Search.GetCompanyProducts}", page, pageSize, slug));
        }
    }
}