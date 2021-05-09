using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company {
    public class GroupCategoryResponse : BaseResponse {
        [JsonProperty ("data")]
        public List<GroupCategoryDto> GroupCategory { get; set; }
    }
}