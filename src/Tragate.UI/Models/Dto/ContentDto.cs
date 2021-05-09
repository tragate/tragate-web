using System;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;

public class ContentDto {
    [JsonProperty ("id")]
    public int Id { get; set; }

    [JsonProperty ("title")]
    public string Title { get; set; }

    [JsonProperty ("slug")]
    public string Slug { get; set; }

    [JsonProperty ("description")]
    public string Description { get; set; }

    [JsonProperty ("body")]
    public string Body { get; set; }
}