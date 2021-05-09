using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tragate.UI.Models.Category
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public List<CategoryViewModel> SubCategoryList { get; set; }
    }
}