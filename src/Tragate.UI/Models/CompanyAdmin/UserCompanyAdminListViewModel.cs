using System.Collections.Generic;

namespace Tragate.UI.Models.CompanyAdmin {
    public class UserCompanyAdminListViewModel : BaseListModel {
        public int CompanyId { get; set; }
        public List<UserAdminDto> UserAdminList { get; set; }
    }
}