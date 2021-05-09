using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Parameter
{
    public class ParameterResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<ParameterDto> Parameters { get; set; }
    }
}