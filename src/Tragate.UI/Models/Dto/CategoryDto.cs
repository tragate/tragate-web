using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto {
    public class CategoryDto {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("parentId")]
        public int? ParentId { get; set; }

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("slug")]
        public string Slug { get; set; }

        [JsonProperty ("metaKeyword")]
        public string MetaKeyword { get; set; }

        [JsonProperty ("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty ("hasChild")]
        public bool HasChild { get; set; }

        [JsonProperty ("statusId")]
        public byte StatusId { get; set; }

        [JsonProperty ("imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty ("priority")]
        public string Priority { get; set; }
    }
}