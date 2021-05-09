
using System.ComponentModel;

namespace Tragate.UI.Models.CompanyAdmin
{
    public class CompanyAdminProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Product Title")]
        public string ProductTitle { get; set; }

        [DisplayName("List Image Path")]
        public string ListImagePath { get; set; }

        [DisplayName("Company Title")]
        public string CompanyTitle { get; set; }

        [DisplayName("Product Slug")]
        public string ProductSlug { get; set; }

        [DisplayName("Company Slug")]
        public string CompanySlug { get; set; }

        [DisplayName("Currency")]
        public string Currency { get; set; }

        [DisplayName("UnitType")]
        public string UnitType { get; set; }

        [DisplayName("Price Low")]
        public decimal PriceLow { get; set; }

        [DisplayName("Price High")]
        public decimal PriceHigh { get; set; }

        [DisplayName("Membership Type")]
        public string MembershipType { get; set; }

        [DisplayName("Minimum Order")]
        public int MinimumOrder { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        public int StatusId { get; set; }
        public string CreatedUser { get; set; }

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}