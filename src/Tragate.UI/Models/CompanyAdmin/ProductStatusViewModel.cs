using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.CompanyAdmin
{
    public class ProductStatusViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("statusId")]
        public int StatusId { get; set; }
        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }
    }
}
