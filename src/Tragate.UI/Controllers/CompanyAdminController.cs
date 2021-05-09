using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Product;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    public class CompanyAdminController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICategoryService _categoryService;

        private readonly ICompanyAdminService _companyAdminService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;

        public CompanyAdminController(
            ICompanyService companyService,
            ICompanyAdminService companyAdminService,
            IMapper mapper,
            IApplicationUser applicationUser,
            IProductService productService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _applicationUser = applicationUser;
            _companyService = companyService;
            _companyAdminService = companyAdminService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            var data = _companyAdminService.GetCompanyAdminDashboardInfo(id);

            if (!data.Success) return Redirect("/");

            var vm = _mapper.Map<CompanyAdminDashboardViewModel>(data.CompanyAdminDashboardInfo);

            var todoListResponse = _companyAdminService.GetCompanyAdminTodoListById(id);
            if (todoListResponse.Success)
            {
                vm.CompanyAdminTodoList = todoListResponse.CompanyAdminTodos;
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Products(int id, [FromQuery]string name, [FromQuery]int status, int page = 1, int pageSize = 25)
        {
            return View(ReturnModel(id, name, status, page, pageSize));
        }

        [HttpPost]
        public IActionResult Products(CompanyAdminProductListViewModel model)
        {
            return View(ReturnModel(model.CompanyId, model.SearchKey, model.StatusId, model.PageNumber, model.PageSize));
        }

        private CompanyAdminProductListViewModel ReturnModel(int id, string name, int status, int page = 1, int pageSize = 25)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (result.Success)
            {
                var data = _companyAdminService.GetCompanyAdminProducts(id, name, status, page, pageSize);
                var model = new CompanyAdminProductListViewModel
                {
                    CompanyId = id,
                    ProductList = _mapper.Map<List<CompanyAdminProductViewModel>>(data.CompanyAdminProducts.CompanyAdminProductList),
                    TotalCount = data.CompanyAdminProducts.TotalCount,
                    SearchKey = name,
                    StatusId = status,
                    PageNumber = data.CompanyAdminProducts.PageNumber,
                    PageSize = data.CompanyAdminProducts.PageSize,

                };

                return model;
            }
            return (new CompanyAdminProductListViewModel());
        }

        [Route("companyadmin/product-image-upload/{id:int}/{uuid}")]
        public IActionResult ProductImage(int id, string uuid)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            return View(new ProductImageViewModel() { Id = id, Uuid = uuid, Mode = 0 });
        }

        [Route("companyadmin/product-image-edit/{id:int}/{uuid}/{productId:int}")]
        public IActionResult ProductImageEdit(int id, string uuid, int productId)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");
            ViewBag.IsEditButtonVisible = true;
            ViewBag.IsAlertVisible = true;
            return View("ProductImage", new ProductImageViewModel() { Id = id, Uuid = uuid, Mode = 1, ProductId = productId });
        }
        [Route("companyadmin/product-update-list-image")]
        [HttpPost]
        public JsonResult ProductUpdateListImage(int imageId, int productId)
        {
            var result = _productService.ProductUpdateListImage(imageId, productId, _applicationUser.UserId);
            if (result.Success)
            {
                return Json(result);
            }
            return Json(result);
        }

        [HttpPost]
        [Route("companyadmin/image-upload/{uuid}/{id:int}")]
        public IActionResult UploadProductImage(IFormFile files, string uuid, int id)
        {
            id = _applicationUser.UserId;
            var result = _productService.UploadProfileImage(files, uuid, id);
            if (result.Success)
            {
                return Json(result);
            }
            else
            {
                string errorString = string.Join(",", result.ErrorList);
                throw new InvalidOperationException(errorString);
            }
        }

        [HttpPost]
        [Route("companyadmin/profile-image-upload/{id:int}")]
        public IActionResult UploadProfileImage(IFormFile files, int id)
        {

            var result = _companyAdminService.UploadProfileImage(files, id);
            if (result.Success)
            {
                return Json(result);
            }
            else
            {
                string errorString = string.Join(",", result.ErrorList);
                throw new InvalidOperationException(errorString);
            }
        }


        [Route("companyadmin/get-product-images/{id:int}")]
        [HttpPost]
        public IActionResult GetProductImages(int id)
        {
            var data = _productService.GetProductById(id);
            var vm = _mapper.Map<ProductDetailViewModel>(data.Product);
            return Json(vm.Images);
        }

        [HttpPost]
        [Route("companyadmin/delete-product-images/{id:int}")]
        public IActionResult DeleteProductImages(int id)
        {
            var data = _productService.DeleteProductImage(id);
            return Json(data);
        }


        [Route("companyadmin/product-category/{id}")]
        public IActionResult ProductCategory(int id)
        {
            return View(new ProductAddViewModel() { CompanyId = id });
        }
        [Route("companyadmin/product-category-edit/{id}/{productId}")]
        public IActionResult ProductEditCategory(int id, int productId)
        {
            return View(new ProductUpdateViewModel()
            {
                CompanyId = id,
                Id = productId
            });
        }
        [HttpPost]
        public JsonResult EditCategory(ProductCategoryChangeViewModel model)
        {
            model.UpdatedUserId = _applicationUser.UserId;
            var result = _productService.ProductCategoryChange(model);
            if (result.Success)
            {
                return Json(result);
            }
            return Json(result);
        }
        public IActionResult AddProduct(int id, int categoryId)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            var data = _categoryService.GetCategoryPath(categoryId);
            var company = _mapper.Map<CompanyViewModel>(_companyService.GetCompanyById(id).Company);

            return View(new ProductAddViewModel()
            {
                CompanyId = id,
                CategoryId = categoryId,
                Category = data.CategoryList,
                CompanyName = company.FullName
            });
        }

        [HttpPost]
        [Route("companyadmin/product-add")]
        public IActionResult AddProduct(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.CreatedUserId = _applicationUser.UserId;
                model.StatusId = (int)StatusType.Active;
                var result = _productService.AddProduct(model);

                if (result == null)
                {
                    result = new ProductAddResponse();
                    result.Success = false;
                    result.Message = "Service not responding in a proper way";
                }

                if (result.Success)
                {
                    result.Message = "Product addded successfully.";
                    result.Url = "/companyadmin/product-image-upload/" + model.CompanyId + "/" + result.ProductLinks[0].Href.Split('/')[4];
                }

                return Json(result);
            }
        }
        [Route("companyadmin/copy-product/{id}/{productId}/{categoryId}")]
        public IActionResult CopyProduct(int id, int productId, int categoryId)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");
            var product = _productService.GetProductById(productId).Product;
            var vm = _mapper.Map<ProductCopyViewModel>(product);

            return View(vm);
        }

        [HttpGet]
        [Route("companyadmin/product-edit/{id}/{productId}")]
        public IActionResult EditProduct(int id, int productId)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            var product = _productService.GetProductById(productId).Product;
            var vm = _mapper.Map<ProductUpdateViewModel>(product);
            vm.Id = productId;
            return View(vm);
        }

        [HttpPost]
        [Route("companyadmin/product-edit")]
        public IActionResult EditProduct(ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                // model.CategoryId = 39;
                model.UpdatedUserId = _applicationUser.UserId;
                //model.StatusId = (int)StatusType.Active;
                model.TagIds = new List<int>();
                var result = _productService.UpdateProduct(model);

                if (result == null)
                {
                    result = new BaseResponse();
                    result.Success = false;
                    result.Message = "Service not responding in a proper way";
                }

                if (result.Success)
                    result.Message = "Product updated successfully.";

                return Json(result);
            }
        }

        public IActionResult Admins(int id, [FromQuery] int page = 1)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (result.Success)
            {
                var users = _companyAdminService.GetCompanyAdminsByCompanyId(page, 10, id, (int)StatusType.Active);
                if (result.Success)
                {
                    var model = _mapper.Map<UserCompanyAdminListViewModel>(users.UserAdminListResponse);
                    model.CompanyId = id;
                    return View(model);
                }
            }

            return Redirect("/");
        }

        [HttpPost]
        public JsonResult Create(CompanyAdminCreateViewModel model)
        {
            model.StatusId = (int)StatusType.Active;
            var result = _companyAdminService.AddCompanyAdmin(model);

            return Json(result);
        }

        [Route("companyadmin/delete")]
        public IActionResult Delete(int id)
        {
            var result = _companyAdminService.DeleteCompanyAdmin(id);
            return Json(result);
        }

        public IActionResult Settings(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (result.Success)
            {
                var company = _companyService.GetCompanyById(id);

                if (company.Success)
                {
                    var vm = _mapper.Map<CompanyProfileViewModel>(company.Company);

                    if (company.Company.CategoryList != null)
                        vm.Categories = string.Join(",", company.Company.CategoryList.Select(a => a.Title).ToList());

                    return View(vm);
                }
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (result.Success)
            {
                var company = _companyService.GetCompanyById(id);

                if (company.Success)
                {
                    var vm = _mapper.Map<CompanyProfileViewModel>(company.Company);

                    if (company.Company.CategoryList != null)
                    {
                        vm.CategoryIdString = string.Join(",", company.Company.CategoryList.Select(a => a.Id).ToList());
                    }
                    else
                    {
                        vm.CategoryIdString = "";
                    }

                    return View(vm);
                }
            }

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Edit(CompanyProfileViewModel model)
        {
            model.BusinessTypeList = model.BusinessType.Split(",").Select(Int32.Parse).ToArray();
            model.CategoryIds = model.CategoryIdString.Split(",").Select(Int32.Parse).ToArray();
            model.LocationId = model.StateId;
            var result = _companyService.Update(model);
            if (result.Success)
            {
                return Redirect($"/companyadmin/settings/{model.CompanyId}");
            }

            return View(model);
        }public IActionResult MembershipPayment(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (result.Success)
            {
                var company = _companyService.GetCompanyById(id);

                if (company.Success)
                {
                    var vm = _mapper.Map<CompanyProfileViewModel>(company.Company);

                    if (company.Company.CategoryList != null)
                    {
                        vm.CategoryIdString = string.Join(",", company.Company.CategoryList.Select(a => a.Id).ToList());
                    }
                    else
                    {
                        vm.CategoryIdString = "";
                    }

                    return View(vm);
                }
            }

            return Redirect("/");
        }
        public JsonResult ChangeStatus(ProductStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedUserId = _applicationUser.UserId;
                var result = _productService.ProductChangeStatus(model);
                if (result.Success)
                {
                    return Json(result);
                }
            }
            return Json(null);
        }

        [Route("companyadmin/buyer-quotes/{id}")]
        public IActionResult BuyerQuotes(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            var model = new QuotationCompanyBuyerListViewModel()
            {
                CompanyId = id
            };
            return View(model);
        }

        [Route("companyadmin/seller-quotes/{id}")]
        public IActionResult SellerQuotes(int id)
        {
            var result = _companyAdminService.IsAdminOfCompany(id, _applicationUser.UserId);
            if (!result.Success) return Redirect("/");

            var model = new QuotationCompanySellerListViewModel()
            {
                CompanyId = id
            };
            return View(model);
        }

        [HttpPost]
        [Route("companyadmin/getbuyer-quotes")]
        public JsonResult BuyerQuotes(int id, int quoteStatusId, int page = 1)
        {
            var quote = _companyAdminService.GetCompanyBuyerQuotationList(id, page, 10, quoteStatusId, null);
            var model = new QuotationCompanyBuyerListViewModel()
            {
                PageNumber = page,
                PageSize = quote.QuotationResponse.PageNumber,
                TotalCount = quote.QuotationResponse.TotalCount,
                QuoteStatusId = quoteStatusId,
                QuotationCompanyBuyerList = _mapper.Map<List<QuotationCompanyBuyerViewModel>>(quote.QuotationResponse.QuotationList),
                TotalPage = (int)Math.Ceiling(((double)quote.QuotationResponse.TotalCount / (double)quote.QuotationResponse.PageSize))
            };

            return Json(model);
        }

        [HttpPost]
        [Route("companyadmin/getseller-quotes/")]
        public JsonResult SellerQuotes(int id, int quoteStatusId, int page = 1)
        {
            var quote = _companyAdminService.GetCompanySellerQuotationList(id, page, 10, quoteStatusId, null);
            var model = new QuotationCompanySellerListViewModel()
            {
                PageNumber = page,
                PageSize = quote.QuotationResponse.PageNumber,
                TotalCount = quote.QuotationResponse.TotalCount,
                QuoteStatusId = quoteStatusId,
                QuotationCompanySellerList = _mapper.Map<List<QuotationCompanySellerViewModel>>(quote.QuotationResponse.QuotationList),
                TotalPage = (int)Math.Ceiling(((double)quote.QuotationResponse.TotalCount / (double)quote.QuotationResponse.PageSize))
            };

            return Json(model);
        }
    }
}