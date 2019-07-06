using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ERPAPI.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace ERPAPI

{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RequireManagerRole", policy => policy.RequireRole("Manager"));
            //});


            //services.AddAuthorization(options =>
            //{
            //            options.AddPolicy("RequireAPIAccess", policy => policy.("AccessAPI"));
            //});

            //services.AddAuthorization(options => options.AddPolicy("AnyGCCCountry",
            //           policy => policy.Requirements.Add(new BaseLocationRequirement(new List<string> { "Saudi Arabia", "Kuwait", "United Arab Emirates", "Qatar", "Bahrain", "Oman" }))));
            services.AddSingleton<IAuthorizationHandler, BaseLocationHandler>();

            services.AddAuthorization(options => options.AddPolicy("CoursePaid",
                        policy => policy.Requirements.Add(new CoursePaidRequirement())));
            services.AddSingleton<IAuthorizationHandler, CoursePaidRequirement.CoursePaidHandler>();


            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            //{
            //    Authority = "http://localhost:5000",
            //    ScopeName = "vendorManagementAPI",
            //    RequireHttpsMetadata = false
            //});

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                SignInScheme = "Cookies",

                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,

                ClientId = "clientApi",
                ClientSecret = "secretkey",

                ResponseType = "code id_token",
                Scope = { "vendorManagementAPI", "offline_access" },

                GetClaimsFromUserInfoEndpoint = true,
                SaveTokens = true
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
