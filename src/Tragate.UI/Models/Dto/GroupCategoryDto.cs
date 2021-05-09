using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;

public class GroupCategoryDto {
    [JsonProperty ("categoryTitle")]
    public string GroupCategoryName { get; set; }
    
    [JsonProperty ("categoryGroupImagePath")]
    public string ImagePath { get; set; }

    [JsonProperty ("categoryList")]
    public List<RootCategoryDto> CategoryList { get; set; }
}
