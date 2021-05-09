using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company
{
    public class CompanyViewModel
    {
        public int PersonId { get; set; }

        [DisplayName("Company name")]
        [Required(ErrorMessage = "Company name is required")]
        public string FullName { get; set; }

        [DisplayName("Business type")]
        [Required]
        public string BusinessType { get; set; }

        [DisplayName("Country")]
        [Required]
        public int? CountryId { get; set; }

        [DisplayName("State")]
        [Required]
        public int? StateId { get; set; }

        public int LocationId { get; set; }

        public int StatusId { get; set; }

        public string CategoryIdString { get; set; }

        [JsonProperty("categoryIds")]
        public int[] CategoryIds { get; set; }

        [JsonProperty("email")]
        public string CompanyEmail { get; set; }

        [JsonProperty("userEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("phone")]
        public string CompanyPhone { get; set; }
    }
}