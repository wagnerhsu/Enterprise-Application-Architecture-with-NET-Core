using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CookieAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
             ViewData["ReturnUrl"] = "hello";
            return View();
        }
        

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("CookiesAuth");
            return Redirect("/");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {

            var claim = new Claim[]
            {
                new Claim("sub","123456789"),
                new Claim("name","ovaismehboob"),
                new Claim("email","ovaismehboob@yahoo.com"),
                new Claim("twitter","ovaismehboob"),
                new Claim("role", "Admin"),
                new Claim("role", "User")

            };
            ClaimsIdentity claimIdentity = new ClaimsIdentity(claim, "CookiesAuth");

            HttpContext.Authentication.SignInAsync("CookiesAuth", 
                new System.Security.Claims.ClaimsPrincipal(claimIdentity));

            return Redirect("/Home/About");
        }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class CookieEvents
    {
        public static async Task ValidateUserPermissions(CookieValidatePrincipalContext context)
        {
            bool pathExist = CheckIfPageExist(context.HttpContext.Request.Path.Value, context.HttpContext.User.Claims);
        //    if (!pathExist)
          //  {
             //   context.HttpContext.Response.Redirect("/Home/About");
           // }
            
        }

        public static bool CheckIfPageExist(string path, IEnumerable<Claim> claims)
        {
            return true;
        }
    }
}
