using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class CompanyAdminProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productTitle")]
        public string ProductTitle { get; set; }

        [JsonProperty("listImagePath")]
        public string ListImagePath { get; set; }

        [JsonProperty("companyTitle")]
        public string CompanyTitle { get; set; }

        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }

        [JsonProperty("companySlug")]
        public string CompanySlug { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("unitType")]
        public string UnitType { get; set; }

        [JsonProperty("priceLow")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("membershipType")]
        public string MembershipType { get; set; }

        [JsonProperty("minimumOrder")]
        public int MinimumOrder { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }
        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("categoryTitle")]
        public string CategoryTitle { get; set; }
    }
}
