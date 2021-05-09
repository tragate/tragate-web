using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.CompanyAdmin {
    public class UserCompanyAdminListResponseMessage : BaseResponse {
        [JsonProperty ("data")]
        public UserCompanyAdminListResponse UserAdminListResponse { get; set; }
    }

    public class UserCompanyAdminListResponse : BaseListResponse {
        [JsonProperty ("dataList")]
        public List<UserAdminDto> UserAdminList { get; set; }

    }
}