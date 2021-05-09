using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto.Quotation
{
    public class QuotationBuyerUserDto : BaseQuotationDto
    {
        [JsonProperty("countryId")]
        public int? CountryId { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
