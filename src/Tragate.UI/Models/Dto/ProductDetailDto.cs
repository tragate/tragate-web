using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class ProductDetailDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uuId")]
        public Guid UuId { get; set; }

        [JsonProperty("productTitle")]
        public string ProductTitle { get; set; }

        [JsonProperty("companyTitle")]
        public string CompanyTitle { get; set; }

        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }

        [JsonProperty("companySlug")]
        public string CompanySlug { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("membershipTypeId")]
        public int MembershipTypeId { get; set; }

        [JsonProperty("membershipType")]
        public string MembershipType { get; set; }

        [JsonProperty("verificationTypeId")]
        public int VerificationTypeId { get; set; }

        [JsonProperty("verificationType")]
        public string VerificationType { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("transactionAmount")]
        public int TransactionAmount { get; set; }

        [JsonProperty("transactionCount")]
        public int TransactionCount { get; set; }

        [JsonProperty("responseRate")]
        public string ResponseRate { get; set; }

        [JsonProperty("responseTime")]
        public string ResponseTime { get; set; }

        [JsonProperty("establishmentYear")]
        public string EstablishmentYear { get; set; }

        [JsonProperty("images")]
        public List<ProductImageDto> Images { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("priceLow")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currencyId")]
        public int? CurrencyId { get; set; }

        [JsonProperty("unitType")]
        public string UnitType { get; set; }

        [JsonProperty("unitTypeId")]
        public int? UnitTypeId { get; set; }

        [JsonProperty("minimumOrder")]
        public int? MinimumOrder { get; set; }

        [JsonProperty("originLocation")]
        public string OriginLocation { get; set; }

        [JsonProperty("originLocationId")]
        public int OriginLocationId { get; set; }

        [JsonProperty("supplyAbility")]
        public int? SupplyAbility { get; set; }

        [JsonProperty("shippingDetail")]
        public string ShippingDetail { get; set; }

        [JsonProperty("packagingDetail")]
        public string PackagingDetail { get; set; }

        [JsonProperty("category")]
        public List<CategoryDto> Category { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [JsonProperty("companyStatusId")]
        public int CompanyStatusId { get; set; }

        [JsonProperty("listImagePath")]
        public string ListImagePath { get; set; }

    }
}