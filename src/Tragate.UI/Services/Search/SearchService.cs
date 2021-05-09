using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Search;

namespace Tragate.UI.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public SearchService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public SearchProductResponseMessage SearchProduct(int page, int pageSize, string key, string categorySlug, string companySlug)
        {
            return _restClient.Get<SearchProductResponseMessage>(string.Format($"{_settings.ApiUrl}/{API.Search.ProductSearch}", page, pageSize, key, categorySlug, companySlug));
        }

        public SearchCompanyResponseMessage SearchCompany(int page, int pageSize, string key, string categoryTag)
        {
            return _restClient.Get<SearchCompanyResponseMessage>(string.Format($"{_settings.ApiUrl}/{API.Search.CompanySearch}", page, pageSize, key, categoryTag));
        }
    }
}