using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;
using Tragate.UI.Services;

namespace Tragate.UI.Filters
{
    public class ProductStatusValidationFilterAttribute : IActionFilter
    {
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;

        public ProductStatusValidationFilterAttribute(IProductService productService, ICompanyService companyService)
        {
            _productService = productService;
            _companyService = companyService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var slug = (string) context.ActionArguments.Single(x => x.Key == "slug" || x.Key == "productslug").Value;
            var product = _productService.GetProductBySlug(slug);

            if (product == null)
                context.Result = new RedirectResult("/error/404");

            if (product == null) return;
            CheckProductStatus(product.Product, context);
            CheckCompanyStatus(product.Product.CompanyId, context);
        }

        private void CheckProductStatus(ProductDetailDto product, ActionExecutingContext context)
        {
            if (product.StatusId == (int) StatusType.Passive || product.StatusId == (int) StatusType.Deleted)
                context.Result = new RedirectResult("/", true);
        }

        private void CheckCompanyStatus(int companyId, ActionExecutingContext context)
        {
            var company = _companyService.GetCompanyById(companyId);
            if (company.Company.StatusId == (int) StatusType.Passive ||
                company.Company.StatusId == (int) StatusType.Deleted)
                context.Result = new RedirectResult("/", true);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}