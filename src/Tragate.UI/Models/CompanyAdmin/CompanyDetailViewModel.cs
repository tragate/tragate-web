using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.CompanyAdmin {
    public class CompanyDetailViewModel {

        [DisplayName ("id")]
        public int? CompanyId { get; set; }

        [DisplayName ("Company Name")]
        public string Name { get; set; }

        [DisplayName ("description")]
        public string Description { get; set; }

        [DisplayName ("Establishment Year")]
        public string EstablishmentYear { get; set; }

        [DisplayName ("taxOffice")]
        public string TaxOffice { get; set; }

        [DisplayName ("taxNumber")]
        public string TaxNumber { get; set; }

        [DisplayName ("annualRevenueId")]
        public int AnnualRevenueId { get; set; }

        [DisplayName ("Annual Revenue")]
        public string AnnualRevenue { get; set; }

        [DisplayName ("employeeCountId")]
        public int EmployeeCountId { get; set; }

        [DisplayName ("Employee Count")]
        public string EmployeeCount { get; set; }

        [DisplayName ("address")]
        public string Address { get; set; }

        [DisplayName ("Website")]
        public string Website { get; set; }

        [DisplayName ("locationId")]
        public int? LocationId { get; set; }

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }

        [DisplayName ("countryId")]
        public int? CountryId { get; set; }

        [DisplayName ("stateId")]
        public int? StateId { get; set; }

        [DisplayName ("statusId")]
        public int StatusId { get; set; }

        [DisplayName ("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [DisplayName ("businessType")]
        public string BusinessType { get; set; }

        public string BusinessTypeString { get; set; }

        public int[] BusinessTypeList { get; set; }
    }
}