using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.CompanyAdmin
{
    public class CompanyAdminDashboardViewModel
    {
        [DisplayName("Message Count")]
        public int MessageCount { get; set; }

        [DisplayName("Quote Count")]
        public int QuoteCount { get; set; }

        [DisplayName("Product Count")]
        public string ProductCount { get; set; }

        [DisplayName("Admin Count")]
        public int AdminCount { get; set; }

        public List<CompanyAdminTodoListDto> CompanyAdminTodoList { get; set; }
    }
}