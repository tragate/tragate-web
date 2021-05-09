using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationBuyerBaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SellerCompanyProfileImage { get; set; }

        public string SellerUser { get; set; }

        public string SellerCompany { get; set; }

        public int QuoteStatusId { get; set; }

        public string OrderStatus { get; set; }

        public string SellerContactStatus { get; set; }

        public int SellerContactStatusId { get; set; }

        public int BuyerContactStatusId { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
