using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Category;
using Tragate.UI.Services.Search;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public SearchController(ISearchService searchService,
            IMapper mapper, IHttpContextAccessor httpAccessor, ICategoryService categoryService)
        {
            _searchService = searchService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [Route("search")]
        public IActionResult OldSearch(int searchTypeId, string key, string category, int page = 1)
        {
            switch (searchTypeId)
            {
                case (int)SearchType.Company:
                    return RedirectToActionPermanent("Companies", new { category = "all" });
                case (int)SearchType.Product:
                default:
                    return RedirectToActionPermanent("Products", new { category = "all" });
            }
        }

        [Route("{category}/products")]
        public IActionResult Products(string key, string category, int page = 1)
        {
            var result = _searchService.SearchProduct(page, 20, key, category == "all" ? null : category, string.Empty);
            @ViewData["SearchType"] = "Products";

            if (result.Success && result.SearchProductListResponse.TotalCount > 0 || string.IsNullOrWhiteSpace(key))
            {
                var products = _mapper.Map<List<ProductViewModel>>(result.SearchProductListResponse.SearchProductList);
                var categories = _categoryService.GetCategoryPath(category == "all" ? null : category);
                var subCategories = _categoryService.GetCategoryBySlugAndStatus(category == "all" ? null : category, (int)StatusType.Active);
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories.CategoryList);
                var subCategoryList = _mapper.Map<List<CategoryViewModel>>(subCategories.CategoryList);
                return View(new ProductPageViewModel()
                {
                    ProductList = products,
                    Category = category,
                    CategoryList = categoryList,
                    SubCategoryList = subCategoryList,
                    SearchKey = key,
                    TotalCount = result.SearchProductListResponse.TotalCount,
                    PageNumber = page,
                    PageSize = 20,
                });
            }
            else
            {
                var companySearch = _searchService.SearchCompany(page, 20, key, category == "all" ? null : category);
                var categories = _categoryService.GetCategoryPath(category == "all" ? null : category);
                var subCategories = _categoryService.GetCategoryBySlugAndStatus(null, (int)StatusType.Active);
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories.CategoryList);
                var subCategoryList = _mapper.Map<List<CategoryViewModel>>(subCategories.CategoryList);
                if (companySearch.Success && companySearch.SearchCompanyListResponse.TotalCount > 0)
                {
                    @ViewData["SearchType"] = "Companies";
                    var companies = _mapper.Map<List<CompanySearchViewModel>>(companySearch.SearchCompanyListResponse.SearchCompanyList);
                    return View("Companies", new CompanyPageViewModel()
                    {
                        CompanyList = companies,
                        Category = category,
                        CategoryList = categoryList,
                        SubCategoryList = subCategoryList,
                        SearchKey = key,
                        TotalCount = companySearch.SearchCompanyListResponse.TotalCount,
                        PageNumber = page,
                        PageSize = 20,
                    });
                }
                return View(new ProductPageViewModel()
                {
                    Category = category,
                    CategoryList = categoryList,
                    SubCategoryList = subCategoryList,
                    SearchKey = key,
                    TotalCount = 0,
                    PageNumber = page,
                    PageSize = 20,
                });
            }

            return View();
        }

        [Route("{category}/companies")]
        public IActionResult Companies(string key, string category, int page = 1)
        {
            var result = _searchService.SearchCompany(page, 20, key, category == "all" ? null : category);
            if (result.Success)
            {
                @ViewData["SearchType"] = "Companies";
                var companies = _mapper.Map<List<CompanySearchViewModel>>(result.SearchCompanyListResponse.SearchCompanyList);
                var categories = _categoryService.GetCategoryPath(category == "all" ? null : category);
                var subCategories = _categoryService.GetCategoryBySlugAndStatus(null, (int)StatusType.Active);
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categories.CategoryList);
                var subCategoryList = _mapper.Map<List<CategoryViewModel>>(subCategories.CategoryList);
                return View(new CompanyPageViewModel()
                {
                    CompanyList = companies,
                    Category = category,
                    CategoryList = categoryList,
                    SubCategoryList = subCategoryList,
                    SearchKey = key,
                    TotalCount = result.SearchCompanyListResponse.TotalCount,
                    PageNumber = page,
                    PageSize = 20,
                });
            }

            return View();
        }
    }
}