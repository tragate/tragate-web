using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Product
{
    public class ProductBaseViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [DisplayName("Company")]
        public string CompanyName { get; set; }

        public List<CategoryDto> Category { get; set; }

        [JsonProperty("title")]
        [DisplayName("Product Title")]
        public string ProductTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("modelNumber")]
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }

        [JsonProperty("originLocationId")]
        [DisplayName("Place Of Origin")]
        public int OriginLocationId { get; set; }

        [JsonProperty("unitTypeId")]
        [DisplayName("Unit Type")]
        public int? UnitTypeId { get; set; }

        [JsonProperty("currencyId")]
        [DisplayName("Currency")]
        public int? CurrencyId { get; set; }

        [JsonProperty("priceLow")]
        [DisplayName("Price Low")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        [DisplayName("Price High")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("categoryId")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [JsonProperty("minimumOrder")]
        [DisplayName("Minimum Order")]
        public int? MinimumOrder { get; set; }

        [JsonProperty("supplyAbility")]
        [DisplayName("Supply Ability")]
        public int? SupplyAbility { get; set; }

        [JsonProperty("shippingDetail")]
        [DisplayName("Shipping Detail")]
        public string ShippingDetail { get; set; }

        [JsonProperty("packagingDetail")]
        [DisplayName("Packaging Detail")]
        public string PackagingDetail { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("statusId")]
        [DisplayName("Status")]
        public int? StatusId { get; set; }

        [JsonProperty("tagIds")]
        public List<int> TagIds { get; set; }
    }
}
