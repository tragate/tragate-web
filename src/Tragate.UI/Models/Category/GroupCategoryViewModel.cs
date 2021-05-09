using System.Collections.Generic;

namespace Tragate.UI.Models.Category {
    public class GroupCategoryViewModel {
        public string GroupCategoryName { get; set; }
        public string ImagePath { get; set; }
        public List<CategoryViewModel> CategoryList { get; set; }
    }
}