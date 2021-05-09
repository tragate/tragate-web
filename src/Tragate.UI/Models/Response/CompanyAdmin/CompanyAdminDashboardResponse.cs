using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.CompanyAdmin {
    public class CompanyAdminDashboardResponse : BaseResponse {
        [JsonProperty ("data")]
        public CompanyAdminDashboardDto CompanyAdminDashboardInfo { get; set; }
    }
}