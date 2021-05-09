using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationSellerBaseViewModel
    {
        public int Id { get; set; }

        public string BuyerUserProfileImage { get; set; }

        public string BuyerUser { get; set; }

        public string BuyerUserEmail { get; set; }

        public string BuyerCompany { get; set; }

        public string BuyerContactStatus { get; set; }

        public int BuyerContactStatusId { get; set; }

        public int SellerContactStatusId { get; set; }

        public int QuoteStatusId { get; set; }

        public string BuyerUserCountry { get; set; }

        public string Title { get; set; }

        public string OrderStatus { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
