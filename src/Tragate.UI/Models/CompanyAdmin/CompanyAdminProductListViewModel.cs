using System.Collections.Generic;
using Tragate.UI.Models.CompanyAdmin;

namespace Tragate.UI.Models.CompanyAdmin
{
    public class CompanyAdminProductListViewModel : BaseListModel
    {
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        public List<CompanyAdminProductViewModel> ProductList { get; set; }
    }
}