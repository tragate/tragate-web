using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto.Quotation
{
    public class QuotationHistoryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quoteId")]
        public int QuoteId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }

        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
