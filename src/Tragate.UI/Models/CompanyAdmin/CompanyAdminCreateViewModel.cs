using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.CompanyAdmin {
    public class CompanyAdminCreateViewModel {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty ("email")]
        public string Email { get; set; }

        [JsonProperty ("companyAdminRoleId")]
        public int RoleId { get; set; }

        [JsonProperty ("statusId")]
        public int StatusId { get; set; }
    }
}