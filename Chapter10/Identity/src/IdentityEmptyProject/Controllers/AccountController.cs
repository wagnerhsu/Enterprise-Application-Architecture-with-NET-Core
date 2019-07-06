using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IdentityEmptyProject.Data;
using IdentityEmptyProject.Models;
using System.Security.Principal;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityEmptyProject.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        UserManager<ApplicationUser> _userManager;


        public AccountController(Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser> signInManager, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {

            var result = await _userManager.CreateAsync(new ApplicationUser { Email = userViewModel.Email, UserName = userViewModel.UserName, TwitterHandler = userViewModel.TwitterHandle, LinkedInProfileLink = userViewModel.LinkedInProfile }, userViewModel.Password);
            return View();
        }


        public IActionResult Login()
        {


            var claim = new Claim[]
            {
                new Claim("username","ovaismehboob"),
                new Claim("email","ovaismehboob@yahoo.com"),
                new Claim("twitter","ovaismehboob")
                
            };
            ClaimsIdentity claimIdentity = new ClaimsIdentity(claim);

            HttpContext.Authentication.SignInAsync("Cookies", new System.Security.Claims.ClaimsPrincipal(claimIdentity));
            return View();
        }


    }
}
