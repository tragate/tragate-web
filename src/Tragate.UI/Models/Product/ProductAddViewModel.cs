
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Product
{
    public class ProductAddViewModel : ProductBaseViewModel
    {
        [JsonProperty("uuId")]
        public Guid UuId { get; set; }
        [DisplayName("State")]
        public int? StateId { get; set; }

        [JsonProperty("createdUserId")]
        public int? CreatedUserId { get; set; }
    }
}