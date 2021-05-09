using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tragate.UI.Models.Dto
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("fullName")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonProperty("locationId")]
        public int? LocationId { get; set; }

        [JsonProperty("timezoneId")]
        public int? TimezoneId { get; set; }

        [JsonProperty("languageId")]
        public int? LanguageId { get; set; }

        [JsonProperty("countryId")]
        public int? CountryId { get; set; }

        [JsonProperty("stateId")]
        public int StateId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("location")]
        public LocationDto Location { get; set; }

        [JsonProperty("country")]
        public LocationDto Country { get; set; }
    }
}