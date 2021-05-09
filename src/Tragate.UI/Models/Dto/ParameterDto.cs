using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class ParameterDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}


        