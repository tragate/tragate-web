using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class ProductImageDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}