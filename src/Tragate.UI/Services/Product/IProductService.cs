using Microsoft.AspNetCore.Http;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Product;

namespace Tragate.UI.Services
{
    public interface IProductService
    {
        ProductDetailResponse GetProductById(int productId);

        ProductDetailResponse GetProductBySlug(string slug);
        ProductAddResponse AddProduct(ProductAddViewModel model);
        BaseResponse UpdateProduct(ProductUpdateViewModel model);
        BaseResponse UploadProfileImage(IFormFile files, string uuid, int id);
        BaseResponse DeleteProductImage(int productId);
        BaseResponse ProductChangeStatus(ProductStatusViewModel model);
        BaseResponse ProductCategoryChange(ProductCategoryChangeViewModel model);
        BaseResponse ProductUpdateListImage(int imageId, int productId, int userId);
    }
}