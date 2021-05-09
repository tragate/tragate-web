using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Filters;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IProductService _productService;
        private readonly IApplicationUser _applicationUser;
        private readonly IMapper _mapper;

        public CompanyController(
            IUserService userService,
            ICompanyService companyService,
            IProductService productService,
            IApplicationUser applicationUser,
            IMapper mapper){
            _userService = userService;
            _companyService = companyService;
            _productService = productService;
            _applicationUser = applicationUser;
            _mapper = mapper;
        }

        [Route("{slug}/home")]
        // [ServiceFilter(typeof(CompanyStatusValidationFilterAttribute))]
        public IActionResult Home(string slug){
            var result = _companyService.GetCompanyBySlug(slug);
            if(!result.Success || result.Company == null || result.Company.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");

            var vm = _mapper.Map<CompanyProfileViewModel>(result.Company);
            var productList = _companyService.GetCompanyProducts(slug, 1, 4);

            vm.CompanyProductList =
                _mapper.Map<List<CompanyProductViewModel>>(productList.CompanyProducts.CompanyProductList);

            return View(vm);
        }

        [Route("{slug}/about")]
        public IActionResult About(string slug){
            var result = _companyService.GetCompanyBySlug(slug);
            if(!result.Success || result.Company == null || result.Company.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");

            var vm = _mapper.Map<CompanyProfileViewModel>(result.Company);

            if (result.Company.CategoryList != null)
                vm.Categories = string.Join(", ", result.Company.CategoryList.Select(a => a.Title).ToList());

            return View(vm);
        }

        [Route("{slug}/cproducts")]
        public IActionResult Products(string slug, [FromQuery] int page = 1){
            int pageSize = 20;
            var company = _companyService.GetCompanyBySlug(slug);
            if(!company.Success || company.Company == null || company.Company.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");
            var productList = _companyService.GetCompanyProducts(slug, page, pageSize);

            var vm = new CompanyProductListViewModel();

            //company header component için değerler veriliyor
            vm.Slug = company.Company.Slug;
            vm.Name = company.Company.User.UserName;
            vm.CompanyId = company.Company.User.UserId;
            vm.ProfileImagePath = company.Company.User.ProfileImagePath;
            vm.MembershipType = company.Company.MembershipType;
            vm.MembershipTypeId = company.Company.MembershipTypeId;
            vm.VerificationType = company.Company.VerificationType;
            vm.VerificationTypeId = company.Company.VerificationTypeId;

            vm.PageSize =
                Convert.ToInt32(Math.Ceiling(productList.CompanyProducts.TotalCount / Convert.ToDouble(pageSize)));
            vm.CompanyProductList =
                _mapper.Map<List<CompanyProductViewModel>>(productList.CompanyProducts.CompanyProductList);
            vm.TotalCount = productList.CompanyProducts.TotalCount;
            vm.PageNumber = page;

            return View(vm);
        }
    

        [Route("{productslug}/product")]
        public IActionResult Product(string productslug){
            if(productslug.Contains("_"))
                return RedirectToActionPermanent("Product", new {productslug = productslug.Replace('_','-')});
            var result = _productService.GetProductBySlug(productslug);            
            if(!result.Success || result.Product == null  || result.Product.CompanyStatusId != (int)StatusType.Active || result.Product.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");

            var vm = _mapper.Map<ProductDetailViewModel>(result.Product);
            vm.Slug = vm.CompanySlug;
            vm.CompanyId = result.Product.CompanyId;
            if (result.Product.Category != null)
                vm.Categories = string.Join(",", result.Product.Category.Select(a => a.Title).ToList());

            return View(vm);
        }

        [Route("{slug}/contact")]
        public IActionResult Contact(string slug){
            var result = _companyService.GetCompanyBySlug(slug);
            if(!result.Success || result.Company == null || result.Company.StatusId != (int)StatusType.Active)
                return RedirectPermanent("~/");

            var vm = _mapper.Map<CompanyProfileViewModel>(result.Company);

            if (result.Company.CategoryList != null)
                vm.Categories = string.Join(",", result.Company.CategoryList.Select(a => a.Title).ToList());

            return View(vm);
        }

        [TragateAuthorize]
        [HttpGet("company/register")]
        public IActionResult Register(){
            var result = _userService.GetUser(_applicationUser.UserId);
            if (result.Success){
                CompanyViewModel model = new CompanyViewModel()
                {
                    CountryId = result.User.CountryId,
                    StateId = result.User.StateId,
                    UserEmail = result.User.Email
                };
                return PartialView(model);
            }

            return PartialView(new CompanyViewModel());
        }

        [HttpGet("company/register-confirmed")]
        public IActionResult RegisterConfirmation(){
            return PartialView();
        }

        [TragateAuthorize]
        [HttpPost("company/register")]
        public IActionResult Register(CompanyViewModel model){
            if (!ModelState.IsValid)
                return View(model);
            else{
                model.PersonId = _applicationUser.UserId;
                model.LocationId = model.StateId.Value;
                model.StatusId = (int) StatusType.Active;//To do: WaitingApprove
                model.CategoryIds = model.CategoryIdString.Split(",").Select(Int32.Parse).ToArray();
                var result = _companyService.Register(model);
                return Json(result);
            }
        }
    }
}