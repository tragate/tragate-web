using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DisplayName("Old Password")]
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [Required]
        [DisplayName("New Password")]
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        [Required]
        [DisplayName("Confirm password")]
        [Compare("NewPassword", ErrorMessage = "Password doesn't match.")]
        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

    }
}