using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User {
    public class UserDashboardResponse : BaseResponse {
        [JsonProperty ("data")]
        public UserDashboardDto UserDashboardInfo { get; set; }
    }
}