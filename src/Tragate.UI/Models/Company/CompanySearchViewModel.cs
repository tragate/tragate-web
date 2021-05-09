namespace Tragate.UI.Models.Company
{
    public class CompanySearchViewModel
    {
        public string ProfileImagePath { get; set; } //gelecek
        public string Title { get; set; }
        public string EstablishmentYear { get; set; }
        public string Location { get; set; }
        public string MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        public string VerificationType { get; set; }
        public int VerificationTypeId { get; set; }
        public string Slug { get; set; }
        public string[] CategoryTags { get; set; }
    }
}