using Tragate.UI.Models.Response;
using Tragate.UI.Models.User;

namespace Tragate.UI.Infrastructure
{
    public static class API
    {
        public static class Account
        {
            public const string Login = "account/login";
            public const string SignUp = "account/signup";
            public const string Verify = "account/verify";
            public const string VerifiedUser = "account/{0}";
            public const string ForgotPassword = "account/forgot-password";
            public const string ResetPassword = "account/reset-password";
            public const string CompleteSignUp = "account/complete-signup";
            public const string ExternalLogin = "account/external-login";
            public const string ExternalSignUp = "account/external-signup";
        }

        public static class Company
        {
            public const string Register = "companies";
            public const string Update = "companies/id={0}";
            public const string GetCompanyById = "companies/id={0}";
            public const string GetCompanyBySlug = "companies/{0}";
            public const string GetCompanyProducts = "companies/{0}/products/page={1}/pageSize={2}/{3}";
            public const string GetCompanyBuyerQuotationList = "companies/{0}/buyer-quotes/page={1}/pageSize={2}/{3}";
            public const string GetCompanySellerQuotationList = "companies/{0}/seller-quotes/page={1}/pageSize={2}/{3}";
        }

        public static class Category
        {
            public const string GroupCategory = "categories/category-group";
            public const string CategoryPath = "categories/category-path/{0}";
            public const string CategoryPathBySlug = "categories/category-path/{0}";
            public const string GroupSubCategory = "categories/subcategory-group{0}";
            public const string GetCategoryByIdAndStatus = "categories/status={0}?parentId={1}";
            public const string GetCategoryBySlugAndStatus = "categories/status={0}?slug={1}";
            public const string GetCategories = "categories/status={0}";
        }

        public static class Content
        {
            public const string GetContentBySlug = "contents/slug={0}/statusId={1}";
        }

        public static class CompanyAdmin
        {
            public const string GetCompanyAdminsByCompanyId = "companyadmins/{0}/users/page={1}/pageSize={2}/{3}";
            public const string GetCompanyAdminsByUserId = "companyadmins/{0}/companies/page={1}/pageSize={2}/{3}";
            public const string IsAdminOfCompany = "companyadmins/companyId={0}/loggedUserId={1}";
            public const string CreateCompanyAdmin = "companyadmins";
            public const string UpdateCompanyAdmin = "companyadmins/{0}";
            public const string DeleteCompanyAdmin = "companyadmins/{0}";
            public const string GetCompanyAdminDashboardInfo = "companyadmins/{0}/dashboard";
            public const string UploadProfileImage = "users/{0}/upload-profile-image";
            public const string GetCompanyAdminTodoList = "users/{0}/todo-list";
        }

        public static class User
        {
            public const string GetUser = "users/{0}";
            public const string UpdateUser = "users/{0}";
            public const string ChangePassword = "users/{0}/password";
            public const string GetUserDashboardInfo = "users/{0}/dashboard";
            public const string ChangeProfileImage = "users/{0}/upload-profile-image";
            public const string ChangeEmail = "users/{0}/email";
            public const string GetUserTodoList = "users/{0}/todo-list";
            public const string GetUserBuyerQuotationList = "users/{0}/buyer-quotes/page={1}/pageSize={2}/{3}";
            public const string GetUserSellerQuotationList = "users/{0}/seller-quotes/page={1}/pageSize={2}/{3}";
            public const string GetUserQuoteNotification = "users/{0}/notification-counts";
            public const string SendActivationEmail = "users/send-activation-email";
        }

        public static class Product
        {
            public const string GetProduct = "products/{0}";
            public const string UpdateProduct = "products";
            public const string UploadImage = "productimages/{0}/users/{1}";
            public const string DeleteProduct = "productimages/{0}";
            public const string ProductStatusChange = "products";
            public const string ProductCategoryChange = "products/{0}/categories";
            public const string ProductUpdateListImage = "products/{0}/productimages/{1}?updatedUserId={2}";
        }

        public static class Parameter
        {
            public const string GetParameters = "parameters/{0}?statusId={1}";
        }

        public static class Location
        {
            public const string GetLocations = "locations{0}";
        }

        public static class Search
        {
            public const string ProductSearch =
                "search/product/page={0}/pageSize={1}?key={2}&categorySlug={3}&companySlug={4}";

            public const string CompanySearch = "search/company/page={0}/pageSize={1}?key={2}&categoryTag={3}";

            public const string GetCompanyProducts = "search/product/page={0}/pageSize={1}?companySlug={2}";
        }

        public static class Quotation
        {
            public const string CreateQuotation = "quotes";
            public const string GetQuotationList = "quotes/page={0}/pageSize={1}/{2}";
            public const string GetQuotationById = "quotes/{0}";
            public const string GetQuotationProducts = "quotes/{0}/quote-products";
            public const string GetQuotationHistories = "quotes/{0}/quote-histories";
            public const string CreateQuotationHistory = "quote-histories";
            public const string QuotationContactStatusUpdate = "quotes/{0}/quotes-contact-status/{1}";
        }
    }
}