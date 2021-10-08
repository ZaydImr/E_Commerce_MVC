using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<User> _userConnected;
        private readonly IUnitOfWork<Item> _item;

        public HomeController(IUnitOfWork<User> userConnected, IUnitOfWork<Item> Item)
        {
            _userConnected = userConnected;
            _item = Item;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                UserConnected = _userConnected.Entity.GetById(Guid.Parse("BC511D5F-6B39-4CAD-9DCE-7D506EF6E20F")),
                Items = _item.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        [Authorize]
        public IActionResult Account()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            if (username == "test" && password == "test")
            {
                if (String.IsNullOrEmpty(returnUrl))
                    returnUrl = "/";
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            ViewData["returnUrl"] = returnUrl;
            TempData["Error"] = "Error. Username or password is invalid !!";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        
    }
}
