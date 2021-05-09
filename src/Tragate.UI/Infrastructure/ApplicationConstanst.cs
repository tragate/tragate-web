using System;

namespace Tragate.UI.Infrastructure
{
    public class WebUrl
    {
        public const string UserCompanies = "/User/Company";
        public const string User = "/User";
    }

    public class ApplicationUrl
    {
        public const string ChangeStatus = "/CompanyAdmin/ChangeStatus";
        public const string ProductList = "/CompanyAdmin/ProductList";
    }

    public class Config
    {
        public static readonly string Root = IsProduction() ? "" : "";

        public static bool IsProduction()
        {
            var env = GetEnvironment();
            switch (env)
            {
                case "Development":
                case "Staging":
                    return false;
                case "Production":
                    return true;
                default:
                    return false;
            }
        }

        private static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }
    }
}