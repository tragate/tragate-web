using System;
using Newtonsoft.Json;

public class CompanyAdminDto {

    [JsonProperty ("id")]
    public int Id { get; set; }

    [JsonProperty ("companyId")]
    public int CompanyId { get; set; }

    [JsonProperty ("companyName")]
    public string Name { get; set; }

    [JsonProperty ("role")]
    public string Role { get; set; }

    [JsonProperty ("profileImagePath")]
    public string ProfileImagePath { get; set; }

    [JsonProperty ("slug")]
    public string Slug { get; set; }
}