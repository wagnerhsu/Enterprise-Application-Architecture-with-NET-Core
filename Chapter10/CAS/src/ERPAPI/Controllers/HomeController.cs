using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        // GET: /<controller>/
        public async Task<IActionResult> Index()

        {
            return View();
        }

      
        [Authorize]
        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync("http://localhost:5003/api/vendormanagement");

            ViewBag.Json = JArray.Parse(content);
            return View();
        }
    }
}
