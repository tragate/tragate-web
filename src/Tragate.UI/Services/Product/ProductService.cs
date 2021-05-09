using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Product;

namespace Tragate.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public ProductService(IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public ProductAddResponse AddProduct(ProductAddViewModel model)
        {
            return _restClient.Post<ProductAddResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.UpdateProduct}"), model);
        }

        public ProductDetailResponse GetProductById(int productId)
        {
            return _restClient.Get<ProductDetailResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.GetProduct}", productId));
        }

        public ProductDetailResponse GetProductBySlug(string slug)
        {
            return _restClient.Get<ProductDetailResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.GetProduct}", slug));
        }

        public BaseResponse UpdateProduct(ProductUpdateViewModel model)
        {
            return _restClient.Put<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.UpdateProduct}"), model);
        }

        public BaseResponse DeleteProductImage(int productId)
        {
            return _restClient.Delete<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.DeleteProduct}", productId));
        }

        public BaseResponse UploadProfileImage(IFormFile files, string uuid, int id)
        {
            return _restClient.PostMultipartContent<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Product.UploadImage}", uuid, id), files);
        }
        public BaseResponse ProductChangeStatus(ProductStatusViewModel model)
        {
            var result = _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{API.Product.ProductStatusChange}", model);
            return result;
        }
        public BaseResponse ProductCategoryChange(ProductCategoryChangeViewModel model)
        {
            var result = _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Product.ProductCategoryChange, model.ProductId)}", model);
            return result;
        }

        public BaseResponse ProductUpdateListImage(int imageId, int productId, int userId)
        {
            var result = _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Product.ProductUpdateListImage, productId, imageId, userId)}");
            return result;
        }
    }
}