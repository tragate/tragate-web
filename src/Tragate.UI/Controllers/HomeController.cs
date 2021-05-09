using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Extensions;
using Tragate.UI.Models.Content;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;

        public HomeController(IContentService contentService){
            _contentService = contentService;
        }

        [HttpGet("/")]
        public IActionResult Index(){
            return View();
        }

        [Route("content/{slug}/{json?}")]
        public new IActionResult Content(string slug, string json){
            var result = _contentService.GetContentBySlug(slug, (int) StatusType.Active);

            if (result.Success){
                ViewBag.Json = (json == "json");
                return View(new ContentViewModel()
                {
                    Body = result.Content?.Body.GetHtmlSanitizedText(),
                    Title = result.Content?.Title
                });
            }

            return View();
        }

        [Route("contact")]
        public IActionResult Contact(){
            return View();
        }
    }
}