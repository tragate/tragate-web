using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto.Quotation
{
    public class QuotationDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("buyerCompany")]
        public QuotationBuyerCompanyDto BuyerCompany { get; set; }

        [JsonProperty("productPrice")]
        public decimal? ProductPrice { get; set; }

        [JsonProperty("shippingFee")]
        public decimal? ShippingFee { get; set; }

        [JsonProperty("insuranceFee")]
        public decimal? InsuranceFee { get; set; }

        [JsonProperty("totalPrice")]
        public decimal? TotalPrice { get; set; }

        [JsonProperty("paid")]
        public decimal? Paid { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("currencyId")]
        public int? CurrencyId { get; set; }

        [JsonProperty("cuurency")]
        public string Currency { get; set; }

        [JsonProperty("paymentNote")]
        public string PaymentNote { get; set; }

        [JsonProperty("shipmentNote")]
        public string ShipmentNote { get; set; }

        [JsonProperty("shipmentUserAddressId")]
        public int? ShipmentUserAddressId { get; set; }

        [JsonProperty("shipmentUserAddress")]
        public string ShipmentUserAddress { get; set; }

        [JsonProperty("invoiceUserAddressId")]
        public int? InvoiceUserAddressId { get; set; }

        [JsonProperty("invoiceUserAddress")]
        public string InvoiceUserAddress { get; set; }

        [JsonProperty("tradeTermId")]
        public int? TradeTermId { get; set; }

        [JsonProperty("tradeTerm")]
        public string TradeTerm { get; set; }

        [JsonProperty("shippingMethodId")]
        public int? ShippingMethodId { get; set; }

        [JsonProperty("shippingMethod")]
        public string ShippingMethod { get; set; }

        [JsonProperty("shipmentDate")]
        public DateTime? ShipmentDate { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime? DeliveryDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("quoteStatusId")]
        public int QuoteStatusId { get; set; }

        [JsonProperty("orderStatusId")]
        public int OrderStatusId { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("sellerContactStatusId")]
        public int SellerContactStatusId { get; set; }

        [JsonProperty("sellerContactStatus")]
        public string SellerContactStatus { get; set; }

        [JsonProperty("buyerContactStatusId")]
        public int BuyerContactStatusId { get; set; }

        [JsonProperty("buyerContactStatus")]
        public string BuyerContactStatus { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [JsonProperty("buyerUser")]
        public QuotationBuyerUserDto BuyerUser { get; set; }

        [JsonProperty("sellerUser")]
        public QuotationSellerUserDto SellerUser { get; set; }

        [JsonProperty("sellerCompany")]
        public QuotationSellerCompanyDto SellerCompany { get; set; }
    }
}
