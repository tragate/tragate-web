using Newtonsoft.Json;

namespace Tragate.UI.Models.Response.Content
{
    public class ContentResponse : BaseResponse {
        [JsonProperty ("data")]
        public ContentDto Content { get; set; }
    }
}