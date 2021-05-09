using Tragate.UI.Models.Response.Search;

namespace Tragate.UI.Services.Search
{
    public interface ISearchService
    {
        SearchProductResponseMessage SearchProduct(int page, int pageSize, string key, string categorySlug, string companySlug);
        SearchCompanyResponseMessage SearchCompany(int page, int pageSize, string key, string categoryTag);
    }
}