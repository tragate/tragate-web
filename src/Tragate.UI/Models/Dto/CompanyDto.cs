using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

public class CompanyDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title{ get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("businessType")]
    public string BusinessType { get; set; }

    [JsonProperty("establishmentYear")]
    public string EstablishmentYear { get; set; }

    [JsonProperty("taxOffice")]
    public string TaxOffice { get; set; }

    [JsonProperty("taxNumber")]
    public string TaxNumber { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("website")]
    public string Website { get; set; }

    [JsonProperty("employeeCountId")]
    public int EmployeeCountId { get; set; }

    [JsonProperty("annualRevenueId")]
    public int AnnualRevenueId { get; set; }

    [JsonProperty("statusId")]
    public int StatusId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("user")]
    public UserDto User { get; set; }

    [JsonProperty("businessTypes")]
    public string BusinessTypes { get; set; }

    [JsonProperty("employeeCount")]
    public string EmployeeCount { get; set; }

    [JsonProperty("annualRevenue")]
    public string AnnualRevenue { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }

    [JsonProperty("categoryList")]
    public List<CategoryDto> CategoryList { get; set; }

    [JsonProperty("membershipPackage")]
    public string MembershipPackage { get; set; }

    [JsonProperty("membershipTypeId")]
    public int MembershipTypeId { get; set; }

    [JsonProperty("membershipType")]
    public string MembershipType { get; set; }

    [JsonProperty("verificationTypeId")]
    public int VerificationTypeId { get; set; }

    [JsonProperty("verificationType")]
    public string VerificationType { get; set; }

    [JsonProperty("transactionAmount")]
    public int TransactionAmount { get; set; }

    [JsonProperty("transactionCount")]
    public int TransactionCount { get; set; }

    [JsonProperty("responseRate")]
    public string ResponseRate { get; set; }

    [JsonProperty("responseTime")]
    public string ResponseTime { get; set; }

    [JsonProperty("categoryTags")]
    public string[] CategoryTags { get; set; }

    [JsonProperty("websitePoint")]
    public int? WebsitePoint { get; set; }

    [JsonProperty("websiteProductCount")]
    public int? WebsiteProductCount { get; set; }
}