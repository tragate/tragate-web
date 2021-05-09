using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models;
using Tragate.UI.Models.Company;
using Tragate.UI.Services;

public class CompanyAdminNavigationViewComponent : ViewComponent {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICompanyService _companyService;

    public CompanyAdminNavigationViewComponent (IHttpContextAccessor httpContextAccessor,
        ICompanyService companyService) {
        _httpContextAccessor = httpContextAccessor;
        _companyService = companyService;
    }

    //TODO:<cache expires-after="@TimeSpan.FromSeconds(20)" vary-by-route="id"> olarak companyadminlayout.cshtml içerisinde caching yapılıyor.
    public IViewComponentResult Invoke () {
        var companyId = ViewContext.RouteData.Values["id"];
        if (companyId != null) {
            var result = _companyService.GetCompanyById (Convert.ToInt32 (companyId));
            if (result.Success) {
                return View ("Navigation", new CompanyHeaderViewModel () {
                    CompanyId = result.Company.User.UserId,
                        Name = result.Company.User.UserName
                });
            }
        }

        return View ();
    }
}