using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using StackExchange.Redis;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Filters;
using Tragate.UI.Infrastructure;
using Tragate.UI.Services;
using Tragate.UI.Services.Quotation;
using Tragate.UI.Services.Quote;
using Tragate.UI.Services.Search;

namespace Tragate.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env){
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                    optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Error()
                .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(
                        new Uri(Configuration["ElasticsearchUrl"]))
                    {
                        MinimumLogEventLevel = LogEventLevel.Error,
                        AutoRegisterTemplate = true
                    })
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services){
            // Registers an IDistributedCache to Redis database
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["RedisUrl"];
                options.InstanceName = "tragate-web";
            });

            // Uses IDistributedCache to store per-browser sessions!
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromDays(1); });

            // Uses a designated key in the Redis database to store cookie encryption keys!  
            services.AddDataProtection().SetApplicationName("Web_TragateSharedCookie")
                .PersistKeysToRedis(ConnectionMultiplexer.Connect(Configuration["RedisUrl"]),
                    "Tragate_DataProtectionKeys");

            services.AddAuthentication("TragateIdentity").AddCookie("TragateIdentity", options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = "ReturnUrl";
            });

            services.AddMvc();
            services.AddAutoMapper();
            services.AddCloudscribePagination();
            services.Configure<ConfigSettings>(Configuration);
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

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
            services.AddTransient<IQuotationService, QuotationService>();


            services.AddTransient<IRestClient, RestClient>();
            services.AddSingleton<IApplicationUser, ApplicationUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Filters
            services.AddScoped<ProductStatusValidationFilterAttribute>();
            services.AddScoped<CompanyStatusValidationFilterAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            else{
                app.UseExceptionHandler("/Home/Error");

                app.UseXXssProtection(options => options.EnabledWithBlockMode());
                app.UseXContentTypeOptions();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "confirmation",
                    template: "account/confirmation/{username}",
                    defaults: new {controller = "Account", action = "RegisterConfirmation"}
                );

                routes.MapRoute(
                    name: "verify",
                    template: "account/verify/{token}",
                    defaults: new {controller = "Account", action = "VerifyEmail"}
                );

                routes.MapRoute(
                    name: "reset",
                    template: "account/reset-password/{token}",
                    defaults: new {controller = "Account", action = "ResetPassword"}
                );

                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}