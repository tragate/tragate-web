using System.Collections.Generic;
using Tragate.UI.Models.Category;

namespace Tragate.UI.Models {
    public class BaseListModel {
        public int TotalCount { get; set; }
        public string SearchKey { get; set; }
        public string Category { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public List<CategoryViewModel> CategoryList { get; set; }
        public List<CategoryViewModel> SubCategoryList { get; set; }
    }
}