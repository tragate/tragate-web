using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationUserSellerListViewModel : BaseListModel
    {
        public List<QuotationUserSellerViewModel> QuotationUserSellerList { get; set; }
        public int QuoteStatusId { get; set; }
    }
}
