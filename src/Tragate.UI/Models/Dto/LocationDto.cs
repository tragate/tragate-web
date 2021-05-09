using System;
using Newtonsoft.Json;

public class LocationDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("parentLocationId")]
    public int? ParentLocationId { get; set; }
}