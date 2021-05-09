using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationUserBuyerListViewModel : BaseListModel
    {
        public List<QuotationUserBuyerViewModel> QuotationUserBuyerList { get; set; }
        public int QuoteStatusId { get; set; }
    }
}
