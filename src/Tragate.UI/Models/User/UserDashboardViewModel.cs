using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.User
{
    public class UserDashboardViewModel
    {
        [DisplayName("New Message Count")]
        public int NewMessageCount { get; set; }

        [DisplayName("Total Message Count")]
        public int TotalMessageCount { get; set; }

        [DisplayName("New Quote Count")]
        public int NewQuoteCount { get; set; }

        [DisplayName("Total Quote Count")]
        public int TotalQuoteCount { get; set; }

        [DisplayName("Company Count")]
        public int CompanyCount { get; set; }

        public List<CompanyAdminDto> UserCompanyList { get; set; }

        public List<UserTodoListDto> UserTodoList { get; set; }

    }
}