using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Category;
using Tragate.UI.Services;

namespace ASP.Components.SearchNavigation
{
    public class SearchNavigationViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;

        public SearchNavigationViewComponent(ICategoryService categoryService,
            IMapper mapper,
            IHttpContextAccessor httpAccessor)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _httpAccessor = httpAccessor;
        }

        public IViewComponentResult Invoke(string view = "")
        {
            var categories = _categoryService.GetCategoryByParentIdAndStatus(null, (int)StatusType.Active);
            var model = _mapper.Map<List<CategoryViewModel>>(categories.CategoryList);
            switch (view)
            {
                case "Mobile":
                    return View("CategoryListMobile", model);
                default:
                    return View("Navigation", model);
            }
        }
    }
}