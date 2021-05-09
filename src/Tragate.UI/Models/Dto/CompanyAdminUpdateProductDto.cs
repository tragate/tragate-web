using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class CompanyAdminUpdateProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string ProductTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("originLocationId")]
        public int OriginLocationId { get; set; }

        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("unitTypeId")]
        public string UnitTypeId { get; set; }

        [JsonProperty("priceLow")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("minimumOrder")]
        public int MinimumOrder { get; set; }

        [JsonProperty("supplyAbility")]
        public int SupplyAbility { get; set; }

        [JsonProperty("shippingDetail")]
        public string ShippingDetail { get; set; }

        [JsonProperty("packagingDetail")]
        public string PackagingDetail { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }

        [JsonProperty("tagIds")]
        public List<int> TagIds { get; set; }
    }
}
