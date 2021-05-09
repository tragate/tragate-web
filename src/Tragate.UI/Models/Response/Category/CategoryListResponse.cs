
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Category
{
    public class CategoryListResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<CategoryDto> CategoryList { get; set; }
    }
}