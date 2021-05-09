using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.CompanyAdmin {
    public class CompanyAdminListResponseMessage : BaseResponse {
        [JsonProperty ("data")]
        public CompanyAdminListResponse CompanyAdminListResponse { get; set; }
    }

    public class CompanyAdminListResponse : BaseListResponse {
        [JsonProperty ("dataList")]
        public List<CompanyAdminDto> CompanyAdminList { get; set; }

    }
}