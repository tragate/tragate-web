using System.Text;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Category;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Models.Response.CompanyAdmin;

namespace Tragate.UI.Services {
    public class CategoryService : ICategoryService {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public CategoryService (IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings) {
            _restClient = restClient;
            _settings = settings.Value;
        }

         public CategoryListResponse GetCategoryByParentIdAndStatus(int? id, int status)
        {
            string endpoint = id.HasValue ? string.Format(API.Category.GetCategoryByIdAndStatus, status, id)
            : string.Format(API.Category.GetCategories, status);
            
            var response = _restClient.Get<CategoryListResponse>($"{_settings.ApiUrl}/{endpoint}");
            return response;
        }

         public CategoryListResponse GetCategoryBySlugAndStatus(string slug, int status)
        {            
            return _restClient.Get<CategoryListResponse>(string.Format($"{_settings.ApiUrl}/{API.Category.GetCategoryBySlugAndStatus}",status, slug));
        }

        public CategoryListResponse GetCategoryPath(int categoryId)
        {
            return _restClient.Get<CategoryListResponse> (string.Format ($"{_settings.ApiUrl}/{API.Category.CategoryPath}", categoryId));
        }

        public CategoryListResponse GetCategoryPath(string slug)
        {
            return _restClient.Get<CategoryListResponse> (string.Format ($"{_settings.ApiUrl}/{API.Category.CategoryPathBySlug}", slug));
        }

        public GroupCategoryResponse GetGroupCategory () {
            return _restClient.Get<GroupCategoryResponse> (string.Format ($"{_settings.ApiUrl}/{API.Category.GroupCategory}"));
        }

        public GroupSubCategoryResponse GetGroupSubCategory (int[] parentIds, int pageSize) {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("?");
            foreach (var id in parentIds)
                sb.Append ($"parentId={id}&");
            sb.Append ($"pageSize={pageSize}");
            return _restClient.Get<GroupSubCategoryResponse> (string.Format ($"{_settings.ApiUrl}/{API.Category.GroupSubCategory}",sb.ToString()));
        }
    }
}