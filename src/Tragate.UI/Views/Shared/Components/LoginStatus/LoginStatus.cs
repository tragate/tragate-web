using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models;
using Tragate.UI.Services;

public class LoginStatusViewComponent : ViewComponent
{
    private readonly IApplicationUser _user;
    private readonly IUserService _userService;

    public LoginStatusViewComponent(IApplicationUser user, IUserService userService){
        _user = user;
        _userService = userService;
    }

    public IViewComponentResult Invoke(string view = "")
    {
        var model = new HomeViewModel();
        if (_user.IsAuthenticate){
            model = new HomeViewModel()
            {
                UserId = _user.UserId,
                UserName = _user.UserName.Split(' ')[0]
            };
            var notification = _userService.GetUserQuoteNotificationById(_user.UserId);
            if (notification.Success){
                model.WaitingBuyerCount = notification.NotificationDto.WaitingBuyerCount;
                model.WaitingSellerCount = notification.NotificationDto.WaitingSellerCount;
            }
            if(view == "New")
            {
                return View("NewLoginStatus", model);
            }
            else
            {
                return View("LoggedIn", model);
            }
            
        }

        if (view == "New")
        {
            return View("NewLoginStatus",model);
        }
        else
        {
            return View();
        }
       
    }
}