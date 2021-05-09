using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto.Quotation
{
    public class BaseQuotationDto
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
