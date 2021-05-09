using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User {
    public class UserProfileViewModel {

        [JsonProperty ("id")]
        public int UserId { get; set; }

        [JsonProperty ("fullName")]
        [Required (ErrorMessage = "Full name is required")]
        [DisplayName ("Full name")]
        public string UserName { get; set; }

        [DisplayName ("E-mail")]
        public string Email { get; set; }

        [JsonProperty ("locationId")]
        [DisplayName ("Location")]
        public int? LocationId { get; set; }

        [JsonProperty ("locationName")]
        [DisplayName ("LocationName")]
        public string LocationName { get; set; }

        [JsonProperty ("timezoneId")]
        [DisplayName ("Timezone")]
        public int TimezoneId { get; set; }

        [JsonProperty ("languageId")]
        [DisplayName ("Language")]
        public int LanguageId { get; set; }

        [DisplayName ("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DisplayName ("Country")]
        [Required]
        public int? CountryId { get; set; }

        [DisplayName ("State")]
        [Required]
        public int? StateId { get; set; }

        public string ProfileImagePath { get; set; }

        public string Url{get;set;}
    }
}