using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationAddViewModel
    {
        public string Title { get; set; }
        public string UserMessage { get; set; }

        public int? BuyerUserId { get; set; }
        public int? BuyerCompanyId { get; set; }
        public string BuyerUserEmail { get; set; }
        [JsonProperty("buyerUserCountryId")]
        public int? CountryId { get; set; } //BuyerUserCountryId

        public string Country { get; set; }

        [JsonProperty("buyerUserStateId")]
        public int? StateId { get; set; }  //BuyerUserStateId

        public int SellerCompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public string Location { get; set; }
        public int? SellerUserId { get; set; }
        public int? ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public string ProductNote { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductUnitTypeId { get; set; }
        public int? CreatedUserId { get; set; }
        public bool UserAuthenticate { get; set; }
    }
}
