using System.Collections.Generic;

namespace Tragate.UI.Models.Company
{
    public class CompanyPageViewModel : BaseListModel
    {
        public List<CompanySearchViewModel> CompanyList { get; set; }
    }
}