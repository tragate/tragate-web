using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationCompanySellerListViewModel : BaseListModel
    {
        public List<QuotationCompanySellerViewModel> QuotationCompanySellerList { get; set; }
        public int QuoteStatusId { get; set; }
        public int CompanyId { get; set; }
    }
}
