using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Tragate.UI.Infrastructure
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        string IApplicationUser.UserName
        {
            get => _httpContextAccessor.HttpContext.User.Identity.Name;
            set => ((IApplicationUser)this).UserName = value;
        }

        bool IApplicationUser.IsAuthenticate
        {
            get => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            set => ((IApplicationUser)this).IsAuthenticate = value;
        }

        int IApplicationUser.UserId
        {
            get => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            set => ((IApplicationUser)this).UserId = value;
        }

        string IApplicationUser.Email
        {
            get => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            set => ((IApplicationUser)this).Email = value;
        }

        string IApplicationUser.Country
        {
            get => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value;
            set => ((IApplicationUser)this).Country = value;
        }

        int IApplicationUser.CountryId
        {
            get => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CountryId")?.Value);
            set => ((IApplicationUser)this).CountryId = value;
        }

        string IApplicationUser.Location
        {
            get => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Location")?.Value;
            set => ((IApplicationUser)this).Location = value;
        }

        int IApplicationUser.LocationId
        {
            get => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "LocationId")?.Value);
            set => ((IApplicationUser)this).LocationId = value;
        }
    }
}