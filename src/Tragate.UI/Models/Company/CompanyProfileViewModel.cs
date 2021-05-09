using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Tragate.UI.Models.Category;

namespace Tragate.UI.Models.Company
{
    public class CompanyProfileViewModelBase
    {
        [JsonProperty("id")]
        public int? CompanyId { get; set; }

        [JsonProperty("fullName")]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("description")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Category List")]
        public List<GeneralCategoryViewModel> CategoryList { get; set; }

        [DisplayName("Categories")]
        public string Categories { get; set; }

        public string CategoryIdString { get; set; }

        [JsonProperty("categoryIds")]
        public int[] CategoryIds { get; set; }

        [JsonProperty("establishmentYear")]
        [DisplayName("Establishment Year")]
        public string EstablishmentYear { get; set; }

        [JsonProperty("taxOffice")]
        [DisplayName("Tax Office")]
        public string TaxOffice { get; set; }

        [JsonProperty("taxNumber")]
        [DisplayName("Tax Number")]
        public string TaxNumber { get; set; }

        [JsonProperty("annualRevenueId")]
        public int AnnualRevenueId { get; set; }

        [DisplayName("Annual Revenue")]
        public string AnnualRevenue { get; set; }

        [JsonProperty("employeeCountId")]
        public int EmployeeCountId { get; set; }

        [DisplayName("Employee Count")]
        public string EmployeeCount { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("website")]
        [DisplayName("Web site")]
        public string Website { get; set; }

        [JsonProperty("locationId")]
        public int? LocationId { get; set; }

        public string Location { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("countryId")]
        public int? CountryId { get; set; }

        [DisplayName("stateId")]
        public int? StateId { get; set; }

        [DisplayName("statusId")]
        public int StatusId { get; set; }

        [DisplayName("Company Status")]
        public string Status { get; set; }

        [DisplayName("User Status")]
        public string UserStatus { get; set; }

        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonProperty("businessType")]
        public string BusinessType { get; set; }

        [DisplayName("Business Type")]
        public string BusinessTypeString { get; set; }

        public int[] BusinessTypeList { get; set; }

        [DisplayName("Membership Package")]
        public string MembershipPackage { get; set; }

        [DisplayName("Membership Type")]
        public string MembershipType { get; set; }

        [JsonProperty("membershipTypId")]
        public int MembershipTypeId { get; set; }

        [DisplayName("Verification Type")]
        public string VerificationType { get; set; }

        [JsonProperty("verificationTypeId")]
        public int VerificationTypeId { get; set; }

        [JsonProperty("websitePoint")]
        public int? WebsitePoint { get; set; }

        [JsonProperty("websiteProductCount")]
        public int? WebsiteProductCount { get; set; }

        [DisplayName("Transaction Amount")]
        public int TransactionAmount { get; set; }

        [DisplayName("Transaction Count")]
        public int TransactionCount { get; set; }

        [DisplayName("Response Rate")]
        public string ResponseRate { get; set; }

        [DisplayName("Response Time")]
        public string ResponseTime { get; set; }
    }

    public class CompanyProfileViewModel : CompanyProfileViewModelBase
    {
        public List<CompanyProductViewModel> CompanyProductList { get; set; }
    }
}