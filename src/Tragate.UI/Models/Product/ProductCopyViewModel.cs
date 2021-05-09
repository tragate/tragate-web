using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Product
{
    public class ProductCopyViewModel : ProductBaseViewModel
    {
        [JsonProperty("createdUserId")]
        public int? CreatedUserId { get; set; }
    }
}
