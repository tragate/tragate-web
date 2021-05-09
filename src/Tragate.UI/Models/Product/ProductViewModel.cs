namespace Tragate.UI.Models.Product
{
    public class ProductViewModel
    {
        public string ListImagePath { get; set; }
        public string Currency { get; set; }
        public decimal PriceLow { get; set; }
        public decimal PriceHigh { get; set; }
        public string UnitType { get; set; }
        public string Title { get; set; }
        public int? MinimumOrder { get; set; }
        public string Category { get; set; }//gelecek
        public string CompanyName { get; set; }
        public string MembershipType { get; set; }
        public string CompanySlug { get; set; }
        public string Slug { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
    }
}