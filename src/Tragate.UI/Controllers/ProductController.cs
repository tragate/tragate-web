using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Filters;
using Tragate.UI.Models.Product;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IMapper mapper){
            _productService = productService;
            _mapper = mapper;
        }

        [Route("product/{slug}")]
        public IActionResult Index(string slug){
            if(slug.Contains("_"))
                return RedirectToActionPermanent("Index", new {slug = slug.Replace('_','-')});
            var result = _productService.GetProductBySlug(slug); 
            if(!result.Success || result.Product == null || result.Product.CompanyStatusId != (int)StatusType.Active || result.Product.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");

            var vm = _mapper.Map<ProductDetailViewModel>(result.Product);
            if (result.Product.Category != null)
                vm.Categories = string.Join(",", result.Product.Category.Select(a => a.Title).ToList());

            return View(vm);
        }
    }
}