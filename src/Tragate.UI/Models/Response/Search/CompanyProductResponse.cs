using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company {
    public class CompanyProductResponse : BaseResponse
    {
        [JsonProperty ("data")]
        public CompanyProductListResponse CompanyProducts { get; set; }
    }

    public class CompanyProductListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyProductDto> CompanyProductList { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }
        
        [JsonProperty("pageIndex")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}