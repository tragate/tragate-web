using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class UserDashboardDto
    {
        [JsonProperty("newMessageCount")]
        public int NewMessageCount { get; set; }

        [JsonProperty("totalMessageCount")]
        public int TotalMessageCount { get; set; }

        [JsonProperty("newQuoteCount")]
        public int NewQuoteCount { get; set; }

        [JsonProperty("totalQuoteCount")]
        public int TotalQuoteCount { get; set; }

        [JsonProperty("companyCount")]
        public int CompanyCount { get; set; }
    }
}