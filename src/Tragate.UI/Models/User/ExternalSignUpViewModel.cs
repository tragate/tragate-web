namespace Tragate.UI.Models.User
{
    public class ExternalSignUpViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public string RegisterTypeId { get; set; }

        public string ExternalUserId { get; set; }

        public string ExternalUserToken { get; set; }
    }
}