using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;

public class UserNavigationViewComponent : ViewComponent {

    private readonly IApplicationUser _applicationUser;
    public UserNavigationViewComponent (IApplicationUser applicationUser) {
        _applicationUser = applicationUser;
    }
    public IViewComponentResult Invoke () {

        ViewBag.UserName = _applicationUser.UserName;
        return View ("UserNavigation");
    }
}