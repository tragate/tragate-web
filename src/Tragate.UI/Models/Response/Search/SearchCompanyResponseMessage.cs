using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Response.Search
{
    public class SearchCompanyResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public SearchCompanyListResponse SearchCompanyListResponse { get; set; }
    }

    public class SearchCompanyListResponse : BaseListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyDto> SearchCompanyList { get; set; }
    }
}