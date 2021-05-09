using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationHistoryViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUser { get; set; }

        public string ProfileImagePath { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
