using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationCompanyBuyerListViewModel : BaseListModel
    {
        public List<QuotationCompanyBuyerViewModel> QuotationCompanyBuyerList { get; set; }
        public int QuoteStatusId { get; set; }
        public int CompanyId { get; set; }
    }
}
