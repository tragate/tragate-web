using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Models.Category;
using Tragate.UI.Services;

public class CategoryGroupMenuViewComponent : ViewComponent {
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryGroupMenuViewComponent (
        IMapper mapper,
        ICategoryService categoryService) {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke (string view = "") {
        var result = _categoryService.GetGroupCategory ();
        if (result.Success) {
            var vm = _mapper.Map<List<GroupCategoryViewModel>> (result.GroupCategory);
            if (view == "New")
            {
                return View("NewCategoryGroupMenu", vm);
            }
            else
            {
                return View("CategoryGroupMenu", vm);
            }
        }

        return View ();
    }
}