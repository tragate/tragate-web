using System;
using System.IO;
using AutoMapper;
using StackExchange.Redis;
using Tragate.UI.Services;
using Microsoft.AspNetCore.Http;
using Tragate.UI.Infrastructure;
using Tragate.UI.Services.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Tragate.UI.BuildingBlocks.ApiClient;
using Microsoft.Extensions.DependencyInjection;

namespace Tragate.Tests
{
    public class TestBase
    {
        protected ServiceProvider BuildServiceProvider(){
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var services = new ServiceCollection();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration["RedisUrl"];
                options.InstanceName = "tragate-web";
            });

            // Uses IDistributedCache to store per-browser sessions!
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromDays(1); });

            // Uses a designated key in the Redis database to store cookie encryption keys!  
            services.AddDataProtection().SetApplicationName("Web_TragateSharedCookie")
                .PersistKeysToRedis(ConnectionMultiplexer.Connect(configuration["RedisUrl"]),
                    "Tragate_DataProtectionKeys");

            services.AddAuthentication("TragateIdentity").AddCookie("TragateIdentity", options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = "ReturnUrl";
            });
            services.Configure<ConfigSettings>(configuration);
            services.AddAutoMapper();

            //add application services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyAdminService, CompanyAdminService>();
            services.AddTransient<IParameterService, ParameterService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISearchService, SearchService>();


            services.AddTransient<IRestClient, RestClient>();
            services.AddSingleton<IApplicationUser, ApplicationUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services.BuildServiceProvider();
        }
    }
}