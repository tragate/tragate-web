using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;
        public CategoryController(ICategoryService categoryService,
            IMapper mapper, IApplicationUser applicationUser)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _applicationUser = applicationUser;
        }


        [HttpGet]
        [Route ("get-categories")]
        public IActionResult GetCategories (int? parentId = null) {
            var result = _categoryService.GetCategoryByParentIdAndStatus (parentId, 3);
            var temp = result.CategoryList.Select (a => new ParameterDto () {
                Id =  a.Id, Value = a.Title
            }).OrderBy(a=>a.Value).ToList ();
            return Json (new { success = true, data = temp});
        }

    }
}