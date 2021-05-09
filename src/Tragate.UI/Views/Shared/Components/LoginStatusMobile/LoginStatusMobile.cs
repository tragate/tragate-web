using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models;
using Tragate.UI.Services;

public class LoginStatusMobileViewComponent : ViewComponent
{

    private readonly IApplicationUser _user;
    public LoginStatusMobileViewComponent(IApplicationUser user)
    {
        _user = user;
    }
    public IViewComponentResult Invoke(string view = "")
    {
        switch (view)
        {
            case "New":
                if (_user.IsAuthenticate)
                {
                    return View("NewLoggedIn", new HomeViewModel()
                    {
                        UserId = _user.UserId,
                        UserName = _user.UserName.Split(' ')[0]
                    });
                }
                else
                    return View("NewDefault");
            default:
                if (_user.IsAuthenticate)
                {
                    return View("LoggedIn", new HomeViewModel()
                    {
                        UserId = _user.UserId,
                        UserName = _user.UserName.Split(' ')[0]
                    });
                }
                else
                    return View();
        }
    }
}