using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class VerifyViewModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
