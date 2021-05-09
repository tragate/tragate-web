using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User {
    public class ForgotPasswordViewModel {

        [DisplayName ("Email")]
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress (ErrorMessage = "Email is not in a correct format.")]
        [JsonProperty ("email")]
        public string Email { get; set; }
    }
}