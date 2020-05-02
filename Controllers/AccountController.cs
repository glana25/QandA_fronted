using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Authorize(QandA_lesson1.Models.User user)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return View();
        }
    }
}