using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.User
{
    public class CompleteSignUpViewModel
    {
        public string Token { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string PasswordMatch { get; set; }

        [JsonIgnore]
        public string Email { get; set; }

        [JsonIgnore]
        public string Location { get; set; }
    }
}
