using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Models;

namespace Tragate.UI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
        [Route("error/500")]
        public IActionResult Error500()
        {
            return View();
        }
    }
}
