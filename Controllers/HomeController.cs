using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QandA_lesson1.DataStore;
using QandA_lesson1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace QandA_lesson1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QandAContext _qandAContext;

        public HomeController(ILogger<HomeController> logger, QandAContext qandAContext)
        {
            _logger = logger;
            _qandAContext = qandAContext;
        }

        public IActionResult Index()
        {
            List<Question> questions = _qandAContext.Questions.Include(q => q.User).ToList();
            return View(questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ask(AskQuestionModel askQuestion)
        {
            // User.Identity.Name
            User userDb = _qandAContext.Users.First(u => u.Username == User.Identity.Name);

            //Save to database
            _qandAContext.Questions.Add(new Question
            {
                DateCreated = DateTime.Now,
                Text = askQuestion.Content,
                Title = askQuestion.Title,
                UserId = userDb.Id
            });

            _qandAContext.SaveChanges();
            // Redirect to home/index
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Answers(int id)
        {

            Question question = _qandAContext.Questions.FirstOrDefault(q => q.Id == id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
