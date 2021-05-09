using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Search
{
    public class SearchProductResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public SearchProductListResponse SearchProductListResponse { get; set; }
    }

    public class SearchProductListResponse : BaseListResponse
    {
        [JsonProperty("dataList")]
        public List<ProductDto> SearchProductList { get; set; }
    }
}