using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company {
    public class GroupSubCategoryResponse : BaseResponse {
        [JsonProperty ("data")]
        public List<RootCategoryDto> GroupSubCategory { get; set; }
    }
}