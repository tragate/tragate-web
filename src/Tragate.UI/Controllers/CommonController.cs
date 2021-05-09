using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Services;

namespace Tragate.UI.Controllers
{
    public class CommmonController : Controller
    {
        private readonly IParameterService _parameterService;
        private readonly ILocationService _locationService;

        public CommmonController(IParameterService parameterService,
            ILocationService locationService)
        {
            _parameterService = parameterService;
            _locationService = locationService;
        }

        [HttpGet("common/parameter/{type}")]
        public IActionResult GetParametersByTypeId(string type)
        {
            var result = _parameterService.GetParametersByTypeId(type, (int)StatusType.Active);
            return Json(result);
        }

        [AllowAnonymous]
        [HttpGet("common/location")]
        public IActionResult GetLocation(int? parentId)
        {
            var result = _locationService.GetLocationByParentId(parentId, (int)StatusType.Active);
            return Json(result);
        }
    }
}