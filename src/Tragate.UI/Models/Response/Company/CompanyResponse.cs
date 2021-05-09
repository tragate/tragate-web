using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company {
    public class CompanyResponse : BaseResponse {
        [JsonProperty ("data")]
        public CompanyDto Company { get; set; }
    }
}