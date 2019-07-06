using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public async Task<IActionResult> Index()
        {

            ViewBag.claims= User.Claims.Count();

            //var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            //var client = new HttpClient();
            //client.SetBearerToken(accessToken);
            //var content = await client.GetStringAsync("http://localhost:5003/api/VendorManagement");

            //ViewBag.Json = JArray.Parse(content).ToString();
            //return View("json");


            //var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            //var userInfoClient = new UserInfoClient(disco.UserInfoEndpoint);
            //var response = await userInfoClient.GetAsync();
            //var claims = response.Claims;

            //var response = await userInfoClient.GetAsync(User.Claim);
            //var claims = response.Claims;
            //var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            //var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            ////var tokenResponse = await tokenClient.RequestClientCredentialsAsync("UserManagementAPI");
            //var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("ovais", "password", "UserManagementAPI");

            //if (!tokenResponse.IsError)
            // {
            //    var client = new HttpClient();
            //    client.SetBearerToken(tokenResponse.AccessToken);

            //    var response = await client.GetAsync("http://localhost:5020/api/identity/1");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = response.Content.ReadAsStringAsync().Result;
            //        ViewBag.Content = content;
            //    }
            //}
            return View();

        }

        [Authorize(Roles = "admin")]
        public IActionResult ManageProfile()
        {

            return View();
        }

      


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync("http://localhost:5003/api/vendorManagement");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }



    }
}
