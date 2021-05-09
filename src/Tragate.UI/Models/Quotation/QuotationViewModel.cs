using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BuyerCompany { get; set; }

        public int BuyerCompanyId { get; set; }

        public string BuyerCompanyLogo { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? ShippingFee { get; set; }

        public decimal? InsuranceFee { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? Paid { get; set; }

        public string Balance { get; set; }

        public int? CurrencyId { get; set; }

        public string Currency { get; set; }

        public string PaymentNote { get; set; }

        public string ShipmentNote { get; set; }

        public int? ShipmentUserAddressId { get; set; }

        public string ShipmentUserAddress { get; set; }

        public int? InvoiceUserAddressId { get; set; }

        public string InvoiceUserAddress { get; set; }

        public int? TradeTermId { get; set; }

        public string TradeTerm { get; set; }

        public int? ShippingMethodId { get; set; }

        public string ShippingMethod { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int QuoteStatusId { get; set; }

        public int OrderStatusId { get; set; }

        public string OrderStatus { get; set; }

        public int SellerContactStatusId { get; set; }

        public string SellerContactStatus { get; set; }

        public int BuyerContactStatusId { get; set; }

        public string BuyerContactStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? BuyerUserId { get; set; }

        public string BuyerUserFullName { get; set; }

        public string BuyerUserProfileImagePath { get; set; }

        public string BuyerUserEmail { get; set; }

        public int? BuyerUserCountryId { get; set; }


        public int? SellerUserId { get; set; }

        public string SellerUserFullName { get; set; }

        public string SellerUserProfileImagePath { get; set; }

        public int? SellerUserCountryId { get; set; }

        public int? SellerCompanyId { get; set; }

        public string SellerCompanyName { get; set; }

        public string SellerCompanyLogo { get; set; }
    }
}
