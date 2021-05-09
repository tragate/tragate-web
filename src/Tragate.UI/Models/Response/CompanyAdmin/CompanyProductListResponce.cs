using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.CompanyAdmin {
    public class CompanyAdminProductResponse : BaseResponse
    {
        [JsonProperty ("data")]
        public CompanyAdminProductListResponse CompanyAdminProducts { get; set; }
    }

    public class CompanyAdminProductListResponse : BaseListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyAdminProductDto> CompanyAdminProductList { get; set; }
    }
}