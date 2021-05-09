using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationProductViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductListImagePath { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitTypeId { get; set; }

        public string UnitType { get; set; }

        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
