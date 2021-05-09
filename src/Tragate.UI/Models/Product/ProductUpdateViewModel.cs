
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Product
{
    public class ProductUpdateViewModel : ProductBaseViewModel
    {
        [JsonProperty("uuId")]
        public Guid UuId { get; set; }

        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }
    }
}