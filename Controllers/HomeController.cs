using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QandA_lesson1.DataStore;
using QandA_lesson1.Models;

namespace QandA_lesson1.Controllers
{
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
