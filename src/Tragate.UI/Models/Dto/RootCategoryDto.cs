using System.Collections.Generic;
using Newtonsoft.Json;

public class RootCategoryDto {
    [JsonProperty ("categoryTitle")]
    public string CategoryName { get; set; }

    [JsonProperty ("imagePath")]
    public string ImagePath { get; set; }

    [JsonProperty ("slug")]
    public string Slug { get; set; }
    
    [JsonProperty ("description")]
    public string Description { get; set; }

    [JsonProperty ("subCategoryList")]
    public List<RootCategoryDto> SubCategoryList { get; set; }
}