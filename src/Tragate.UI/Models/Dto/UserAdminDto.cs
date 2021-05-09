using System;
using Newtonsoft.Json;

public class UserAdminDto {

    [JsonProperty ("id")]
    public int Id { get; set; }

    [JsonProperty ("userId")]
    public int UserId { get; set; }

    [JsonProperty ("userName")]
    public string Name { get; set; }

    [JsonProperty ("role")]
    public string Role { get; set; }

    [JsonProperty ("profileImagePath")]
    public string ProfileImagePath { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}