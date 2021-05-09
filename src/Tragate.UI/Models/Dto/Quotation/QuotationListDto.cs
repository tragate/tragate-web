using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Dto
{
    public class QuotationListDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("sellerUser")]
        public QuotationSellerUserDto SellerUser { get; set; }

        [JsonProperty("buyerUser")]
        public QuotationBuyerUserDto BuyerUser { get; set; }

        [JsonProperty("sellerCompany")]
        public QuotationSellerCompanyDto SellerCompany { get; set; }

        [JsonProperty("quoteStatusId")]
        public int QuoteStatusId { get; set; }

        [JsonProperty("orderStatusId")]
        public int OrderStatusId { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("sellerContactStatusId")]
        public int SellerContactStatusId { get; set; }

        [JsonProperty("sellerContactStatus")]
        public string SellerContactStatus { get; set; }

        [JsonProperty("buyerContactStatusId")]
        public int BuyerContactStatusId { get; set; }

        [JsonProperty("buyerContactStatus")]
        public string BuyerContactStatus { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }
}
