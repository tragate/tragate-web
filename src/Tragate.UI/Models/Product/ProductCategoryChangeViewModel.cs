using Newtonsoft.Json;

namespace Tragate.UI.Models.Product
{
    public class ProductCategoryChangeViewModel
    {
        [JsonIgnore]
        public int CompanyId { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }
    }
}
