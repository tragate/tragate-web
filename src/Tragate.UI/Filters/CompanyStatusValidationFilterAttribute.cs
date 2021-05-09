using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tragate.UI.Common.Enums;
using Tragate.UI.Services;

namespace Tragate.UI.Filters
{
    public class CompanyStatusValidationFilterAttribute : IActionFilter
    {
        private readonly ICompanyService _companyService;

        public CompanyStatusValidationFilterAttribute(ICompanyService companyService){
            _companyService = companyService;
        }

        public void OnActionExecuting(ActionExecutingContext context){
            var slug = (string) context.ActionArguments.Single(x => x.Key == "slug")
                .Value;
            var companyResponse = _companyService.GetCompanyBySlug(slug);

            if (companyResponse.Company == null)
                context.Result = new RedirectResult("/error/404");

            if (companyResponse.Company != null){
                switch (companyResponse.Company.StatusId){
                    case (int) StatusType.Passive:
                    case (int) StatusType.Deleted:
                            context.Result = new RedirectResult($"/search?searchTypeId={(int) SearchType.Company}", true);
                        break;
                    }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context){
        }
    }
}