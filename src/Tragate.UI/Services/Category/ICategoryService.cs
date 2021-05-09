using Tragate.UI.Models.Company;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Category;
using Tragate.UI.Models.Response.Company;

namespace Tragate.UI.Services {
    public interface ICategoryService {
        GroupCategoryResponse GetGroupCategory ();
        GroupSubCategoryResponse GetGroupSubCategory (int[] parentIds, int pageSize);
        CategoryListResponse GetCategoryPath(int categoryId);
        CategoryListResponse GetCategoryPath(string slug);
        CategoryListResponse GetCategoryByParentIdAndStatus(int? id, int status);
        CategoryListResponse GetCategoryBySlugAndStatus(string slug, int status);
    }
}