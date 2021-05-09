using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Product {
    public class ProductAddResponse : BaseResponse {
        [JsonProperty ("links")]
        public List<ProductLinkDto> ProductLinks { get; set; }

        public string Url { get; set; }
    }
}