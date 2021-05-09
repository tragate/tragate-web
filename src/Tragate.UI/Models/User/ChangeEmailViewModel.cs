using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class ChangeEmailViewModel
    {
        [JsonProperty("email"), Required, DisplayName("E-mail")]
        public string NewEmail { get; set; }

        [JsonProperty("password"), Required, DisplayName("Password")]
        public string Password { get; set; }
    }
}
