using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Models.Category;
using Tragate.UI.Services;

public class CategoryGroupMenuMobileViewComponent : ViewComponent {
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryGroupMenuMobileViewComponent (
        IMapper mapper,
        ICategoryService categoryService) {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke () {
        var result = _categoryService.GetGroupCategory ();
        if (result.Success) {
            var vm = _mapper.Map<List<GroupCategoryViewModel>> (result.GroupCategory);
            return View ("CategoryGroupMenuMobile", vm);
        }

        return View ();
    }
}