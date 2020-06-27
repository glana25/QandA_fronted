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

            if (!ModelState.IsValid)
            {
                return View();
            }
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
           
            return View("Answers",BuildAnswersModel(id));
        }

       private AnswersModel BuildAnswersModel(int questionId)
        {
            Question question = _qandAContext.Questions.Include(q => q.User).FirstOrDefault(q => q.Id == questionId);

            List<Answer> answersQuestion = _qandAContext.Answers.Include(u => u.User)
                                                                .Where(a => a.QuestionId == question.Id)
                                                                .ToList();
            AnswersModel am = new AnswersModel
            {
                QuestionId = question.Id,
                QuestionText = question.Text,
                QuestionTitle = question.Title,
                QuestionDateCreated = question.DateCreated,
                QuestionUsername = question.User.Username,
                QuestionAnswers = answersQuestion
            };
            return am;
        }
        [HttpPost]
        public IActionResult Answer(int id, [FromForm]AnswersModel answerModel)
        {
            if (!ModelState.IsValid)
            {
                //return our View and pass our paramethers
                return View("Answers", BuildAnswersModel(id));// becaouse our method is name is Answer but View hane is Answers, so we need specify the View Answers
                //return Answers(id);

            }

            var user = _qandAContext.Users.First(u => u.Username == this.User.Identity.Name);

            Answer answerDb = new Answer
            {
                QuestionId = id,
                UserId = user.Id,
                Text = answerModel.Answer,
                DateCreated = DateTime.Now
            };

            _qandAContext.Answers.Add(answerDb);
            _qandAContext.SaveChanges();

            return RedirectToAction(nameof(Answers), new {id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
