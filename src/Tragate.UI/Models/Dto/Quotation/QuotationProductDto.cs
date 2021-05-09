using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto.Quotation
{
    public class QuotationProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quoteId")]
        public int QuoteId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("product")]
        public string ProductTitle { get; set; }

        [JsonProperty("listImagePath")]
        public string ProductListImagePath { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("unitPrice")]
        public decimal? UnitPrice { get; set; }

        [JsonProperty("unitTypeId")]
        public int? UnitTypeId { get; set; }

        [JsonProperty("totalPrice")]
        public decimal? TotalPrice { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
