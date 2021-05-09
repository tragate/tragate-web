using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Location
{
    public class LocationResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<LocationDto> Locations { get; set; }
    }
}