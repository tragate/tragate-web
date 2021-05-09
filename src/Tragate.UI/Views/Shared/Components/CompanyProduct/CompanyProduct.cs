using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Models.Product;

public class CompanyProductViewComponent : ViewComponent {

    public IViewComponentResult Invoke (ProductDetailViewModel model, string view ="") {
        if(view=="new")
            return View ("NewCompanyProduct", model);
        else
            return View ("CompanyProduct", model);
    }
}