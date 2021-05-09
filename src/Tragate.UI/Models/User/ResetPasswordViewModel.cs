using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User
{
    public class ResetPasswordViewModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [JsonProperty("passwordMatch")]
        public string PasswordMatch { get; set; }
    }
}