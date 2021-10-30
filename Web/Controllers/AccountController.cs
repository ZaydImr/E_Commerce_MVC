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

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork<User> _userConnected;

        public AccountController(IUnitOfWork<User> userConnected)
        {
            _userConnected = userConnected;
        }

        [Authorize]
        public  IActionResult Index()
        {
            string username = User.Claims.ToList().Where(c=>c.Type == "username").FirstOrDefault().Value;

            User user = _userConnected.Entity.GetById(username);
            if (user == null)
            {
                return Redirect("/");
            }

            return View(user);
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
            foreach(User user in _userConnected.Entity.GetAll().ToList())
            {
                if(user.Username.ToLower() == username.ToLower() && user.Password == password)
                {
                    if (String.IsNullOrEmpty(returnUrl))
                        returnUrl = "/";
                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", user.Username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Fullname));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect(returnUrl);
                }
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
