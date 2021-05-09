namespace Tragate.UI.Infrastructure
{
    public interface IApplicationUser
    {
        bool IsAuthenticate { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Country { get; set; }
        int CountryId { get; set; }
        string Location { get; set; }
        int LocationId { get; set; }
    }
}