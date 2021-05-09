using Newtonsoft.Json;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Response.User
{
    public class UserQuoteNotificationResponse : BaseResponse
    {
        [JsonProperty("data")]
        public QuoteNotificationDto NotificationDto { get; set; }
    }
}