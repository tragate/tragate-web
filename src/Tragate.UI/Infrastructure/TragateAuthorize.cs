using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tragate.UI.Controllers;
using Tragate.UI.Models.Response;

public class TragateAuthorize : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        /*TODO:session datası kullanılacak ise ve session düştüğünde authenticate ise auto login  yapılıp email'e gore  session yuklenebilir.
        * web contextual olarak singleton user objesi kullanılabilir.
        */
        /*if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            
        }*/

        /*if (context.HttpContext.Session.GetObject<LoginResponse>("session") == null)
        {
            ViewResult result = new ViewResult();
            result.ViewName = "/Views/Account/Login.cshtml";
            context.Result = result;
        }*/
    }
}