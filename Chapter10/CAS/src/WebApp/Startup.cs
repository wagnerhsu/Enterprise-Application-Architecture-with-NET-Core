using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddAuthorization(options => options.AddPolicy("ManageUser", policy => policy.RequireClaim(ClaimTypes.Role,"admin")));
            //services.AddAuthorization(options => options.AddPolicy("policyAdmin", policyUser =>
            //{
            //    policyUser.RequireClaim("givenname", "ovais khan");
            //}));
            //services.AddAuthorization(options => options.AddPolicy("policyUser", policyUser =>
            //{
            //    policyUser.RequireClaim("role", "policy.user");
            //}));

            //  services.AddAuthorization(options => options.AddPolicy("ManageUser", policy => policy.RequireClaim("ManageUser")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                ClientId = "client",
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,
                SignInScheme = "Cookies",
               
                Scope = {"openid", "profile", "roles" },
             
                //      ClientSecret="secret",

                //    ResponseType="code id_token",
                //   Scope = {"UserManagementAPI"},

                //GetClaimsFromUserInfoEndpoint=true,
                //GetClaimsFromUserInfoEndpoint = true,
              //  Scope = { "UserManagementAPI" },

                SaveTokens = true
            });

            app.UseMvcWithDefaultRoute();
            
        }
    }
}
