using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Services;
using Tragate.UI.Services.Quote;

namespace Tragate.UI.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly IApplicationUser _applicationUser;
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public QuoteController(IQuotationService quotationService, IApplicationUser applicationUser,
            IProductService productService, ICompanyService companyService, IMapper mapper)
        {
            _quotationService = quotationService;
            _applicationUser = applicationUser;
            _productService = productService;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("quote/contact-supplier")]
        public IActionResult ContactSupplier(int companyId, int? productId)
        {
            var model = new QuotationAddViewModel();
            if (productId.HasValue)
            {
                var product = _productService.GetProductById(productId.Value);
                if (product != null)
                {
                    model.ProductId = productId;
                    model.ProductTitle = product.Product.ProductTitle;
                    model.ProductImage = product.Product.ListImagePath;
                }
            }

            if (companyId > 0)
            {
                var company = _companyService.GetCompanyById(companyId);
                if (company != null)
                {
                    model.CompanyTitle = company.Company.Title;
                }
            }

            model.SellerCompanyId = companyId;
            model.UserAuthenticate = _applicationUser.IsAuthenticate;

            return Json(model);
        }

        [HttpPost]
        [Route("quote/create-quotation")]
        public IActionResult CreateQuotation(QuotationAddViewModel model)
        {
            if (_applicationUser.IsAuthenticate)
            {
                model.CreatedUserId = _applicationUser.UserId;
                model.BuyerUserId = _applicationUser.UserId;
                model.Title = $"Price request from {_applicationUser.UserName} in {_applicationUser.Country}";
            }
            else
            {
                model.Title = $"Price request from {model.BuyerUserEmail} in {model.Country}";
            }

            var result = _quotationService.AddQuotation(model);
            return Json(result);
        }

        [HttpPost]
        [Route("quote/view-quotation")]
        public JsonResult ViewQuotation(int quoteId)
        {
            var result = _quotationService.GetQuotationById(quoteId);
            var vm = _mapper.Map<QuotationViewModel>(result.Quotation);

            return Json(vm);
        }

        [HttpPost]
        [Route("quote/quotation-product")]
        public JsonResult QuotationProduct(int quoteId)
        {
            var result = _quotationService.GetQuotationProducts(quoteId);
            var model = _mapper.Map<List<QuotationProductViewModel>>(result.QuotationProductsList);

            return Json(model);
        }

        [HttpPost]
        [Route("quote/quotation-history")]
        public JsonResult QuotationHistory(int quoteId)
        {
            var result = _quotationService.GetQuotationHistories(quoteId);
            var model = _mapper.Map<List<QuotationHistoryViewModel>>(result.QuotationHistoryList);

            return Json(model);
        }

        [HttpPost]
        [Route("quote/create-quotation-history")]
        public JsonResult CreateQuotationHistory(QuotationHistoryAddViewModel model)
        {
            model.CreatedUserId = _applicationUser.UserId;
            var result = _quotationService.AddQuotationHistory(model);
            return Json(result);
        }

        [HttpPost]
        [Route("quote/quotation-contact-status")]
        public JsonResult QuotationContactStatusUpdate(int quoteId, int buyerContactStatusId, int sellerContactStatusId)
        {
            if (buyerContactStatusId == (int) QuotationContactStatus.WaitingBuyerResponse)
            {
                buyerContactStatusId = (int) QuotationContactStatus.BuyerRead;

                var result = _quotationService.QuotationContactStatusUpdate(quoteId, buyerContactStatusId,sellerContactStatusId);
                return Json(result);
            }

            if (sellerContactStatusId == (int) QuotationContactStatus.WaitingSellerResponse)
            {
                sellerContactStatusId = (int) QuotationContactStatus.SellerRead;

                var result = _quotationService.QuotationContactStatusUpdate(quoteId, buyerContactStatusId,sellerContactStatusId);
                return Json(result);
            }

            return Json(null);
        }
    }
}