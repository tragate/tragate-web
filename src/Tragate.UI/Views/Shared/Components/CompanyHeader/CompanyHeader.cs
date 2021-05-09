using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Services;

public class CompanyHeaderViewComponent : ViewComponent
{
    private readonly ICompanyService _companyService;
    private readonly ICompanyAdminService _companyAdminService;
    private readonly IApplicationUser _applicationUser;

    public CompanyHeaderViewComponent(
        ICompanyService companyService,
        ICompanyAdminService companyAdminService,
        IApplicationUser applicationUser)
    {
        _companyService = companyService;
        _companyAdminService = companyAdminService;
        _applicationUser = applicationUser;
    }

    public IViewComponentResult Invoke(CompanyProfileViewModelBase company)
    {
        //company product detail da product slug ile çalıştığı için company data get ediliyor
        
            CompanyResponse result;
            if (ViewContext.RouteData.Values["id"] != null) // company admin den geliyorsa
                result = _companyService.GetCompanyById(Convert.ToInt32(ViewContext.RouteData.Values["id"]));
            else if (ViewContext.RouteData.Values["slug"] != null) //company product list
                result = _companyService.GetCompanyBySlug(ViewContext.RouteData.Values["slug"].ToString());
            else // product detail den geliyorsa
                result = _companyService.GetCompanyBySlug(company.Slug);
            
            company.Slug = result.Company.Slug;
            company.Name = result.Company.User.UserName;
            company.CompanyId = result.Company.User.UserId;
            company.ProfileImagePath = result.Company.User.ProfileImagePath;
            company.MembershipType = result.Company.MembershipType;
            company.MembershipTypeId = result.Company.MembershipTypeId;
            company.VerificationType = result.Company.VerificationType;
            company.VerificationTypeId = result.Company.VerificationTypeId;
        
        int userId = _applicationUser.IsAuthenticate ? _applicationUser.UserId : 0;
        bool isAdmin = _companyAdminService.IsAdminOfCompany(company.CompanyId.Value, userId).Success;
        return View("CompanyHeader", new CompanyHeaderViewModel()
        {
            Slug = company.Slug,
            CompanyId = company.CompanyId,
            ProfileImagePath = company.ProfileImagePath,
            MembershipType = company.MembershipType,
            MembershipTypeId = company.MembershipTypeId,
            VerificationType = company.VerificationType,
            VerificationTypeId = company.VerificationTypeId,
            IsAdmin = isAdmin
        });
    }
}