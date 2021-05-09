using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User {
    public class UserRegisterViewModel {
        [JsonProperty ("fullName")]
        [Required (ErrorMessage = "Full name is required")]
        [DisplayName ("Full name")]
        public string FullName { get; set; }

        [JsonProperty ("email")]
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress (ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        [JsonProperty ("password")]
        [Required (ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [JsonProperty ("passwordMatch")]
        [DisplayName ("Confirm password")]
        [Required (ErrorMessage = "Password confirm is required")]
        [Compare ("Password", ErrorMessage = "Password doesn't match.")]
        public string PasswordMatch { get; set; }

        [DisplayName ("Country")]
        [JsonProperty ("countryId")]
        public int CountryId { get; set; }

        [DisplayName ("State")]
        [JsonProperty ("stateId")]
        public int? StateId { get; set; }

        [JsonProperty ("locationId")]
        public int LocationId { get; set; }
    }
}