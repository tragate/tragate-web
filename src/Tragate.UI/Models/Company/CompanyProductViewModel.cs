using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company
{
    public class CompanyProductViewModel
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("listImagePath")]
        public string ListImagePath { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("priceLow")]
        public decimal PriceLow { get; set; }

        [JsonProperty("priceHigh")]
        public decimal PriceHigh { get; set; }

        [JsonProperty("currencyId")]
        public int CurrencyId { get; set; }

        [JsonProperty("unitTypeId")]
        public int UnitTypeId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [DisplayName("Unit Type")]
        public string UnitType { get; set; }

        [DisplayName("Minimum Order")]
        public int MinimumOrder { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("categoryPath")]
        public string CategoryPath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("company")]
        public CompanyDto Company { get; set; }
    }
}