using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;

public class UploadProfileImageViewComponent : ViewComponent {

    private readonly ConfigSettings _settings;
    public UploadProfileImageViewComponent (IOptionsSnapshot<ConfigSettings> settings) {
        _settings = settings.Value;
    }
    public IViewComponentResult Invoke (int userId, string url) {
        ViewBag.Url = _settings.ApiUrl;
        return View ("UploadProfileImage", new UserProfileViewModel () {
            UserId = userId,
            Url = url
        });
    }
}