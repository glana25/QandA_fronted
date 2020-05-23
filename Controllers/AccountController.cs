using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using QandA_lesson1.DataStore;
using QandA_lesson1.Models;

namespace QandA_lesson1.Controllers
{
    public class AccountController : Controller
    {
        // .../account/signin
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Admin()
        {
            var db = new DbHandler();
            var users = db.GetUsers();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Authorize(QandA_lesson1.Models.User user)
        {
            var claims = new List<Claim>();
            var userNameClaim = new Claim(ClaimTypes.Name, user.Username);
            claims.Add(userNameClaim);

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
    }
}