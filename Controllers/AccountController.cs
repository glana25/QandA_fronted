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
        private readonly QandAContext _qandAContext;

        public AccountController(QandAContext qandAContext)
        {
            _qandAContext = qandAContext;
        }

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
        public async Task<IActionResult> Authorize(QandA_lesson1.Models.UserModel user)
        {
            var userExists = _qandAContext.Users.Any(u => u.Username == user.Username && u.Password == user.Password);

            if (!userExists)
            {
                ViewBag.Error = "Invalid user";
                return View("SignIn");
            }

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
            return RedirectToAction(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if(registerUser.Password != registerUser.ConfirmPassword)
            {
                ViewBag.Error = "Password doesn't match";
                return View();
            }

            bool userExists = _qandAContext.Users.Any(u => u.Username.ToLower() == registerUser.Username.ToLower());

            if (userExists)
            {
                ViewBag.Error = "Username already exist";
                return View();
            }

            var user = new User()
            {
                Username = registerUser.Username,
                Password = registerUser.Password
            };

            _qandAContext.Users.Add(user);
            _qandAContext.SaveChanges();

            return await Authorize(new UserModel { Username = user.Username, Password = user.Password });
        }
    }
}