
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Product
{
    public class ProductImageViewModel
    {
        public string Uuid { get; set; }
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int Mode { get; set; }
        
    }
}