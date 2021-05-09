using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

public class CompanyProductDto
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
    public int? CurrencyId { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("unitTypeId")]
    public int? UnitTypeId { get; set; }

    [JsonProperty("unitType")]
    public string UnitType { get; set; }

    [JsonProperty("minimumOrder")]
    public int? MinimumOrder { get; set; }

    [JsonProperty("categoryId")]
    public int CategoryId { get; set; }

    [JsonProperty("statusId")]
    public int StatusId { get; set; }

    [JsonProperty("createdDate")]
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