using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Models.Location;

public class LocationViewComponent : ViewComponent {

    public IViewComponentResult Invoke (int? countryId, int? stateId, string divide="", string countryName="Country", string stateName="State") {

        return View ("Location", new LocationViewModel () {
                CountryId = countryId.HasValue ? countryId.Value : -1,
                StateId = stateId.HasValue ? stateId.Value : -1,
                DivideClass =divide,
                CountryName = countryName,
                StateName = stateName
        });
    }
}