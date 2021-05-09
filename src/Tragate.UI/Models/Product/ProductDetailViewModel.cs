using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Product
{

    public class ProductDetailViewModel : Company.CompanyProfileViewModelBase
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

        [JsonProperty("images")]
        public List<ProductImageDto> Images { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("modelNumber")]
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }

        [JsonProperty("priceLow")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("unitType")]
        public string UnitType { get; set; }

        [JsonProperty("minimumOrder")]
        [DisplayName("Min Order")]
        public int? MinimumOrder { get; set; }

        [JsonProperty("originLocation")]
        [DisplayName("Place of Origin")]
        public string OriginLocation { get; set; }

        [JsonProperty("supplyAbility")]
        [DisplayName("Supply Ability")]
        public int? SupplyAbility { get; set; }

        [JsonProperty("shippingDetail")]
        [DisplayName("Shipping Information")]
        public string ShippingDetail { get; set; }

        [JsonProperty("packagingDetail")]
        [DisplayName("Packaging Information")]
        public string PackagingDetail { get; set; }

        [JsonProperty("category")]
        public List<CategoryDto> Category { get; set; }
    }
}