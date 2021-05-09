using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class CompanyAdminDashboardDto
    {
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        [JsonProperty("quoteCount")]
        public int QuoteCount { get; set; }

        [JsonProperty("productCount")]
        public string ProductCount { get; set; }

        [JsonProperty("adminCount")]
        public int AdminCount { get; set; }
    }
}