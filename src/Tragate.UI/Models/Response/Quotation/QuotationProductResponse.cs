﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Response.Quotation
{
    public class QuotationProductResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<QuotationProductDto> QuotationProductsList { get; set; }
    }
}
