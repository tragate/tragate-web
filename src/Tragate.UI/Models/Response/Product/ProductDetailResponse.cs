using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Product {
    public class ProductDetailResponse : BaseResponse {
        [JsonProperty ("data")]
        public ProductDetailDto Product { get; set; }
    }
}