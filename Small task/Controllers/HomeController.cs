using Microsoft.AspNetCore.Mvc;
using Small_task.Models;
using Small_task.ViewModels;
using System.Diagnostics;

namespace Small_task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hello()
        {
            return View(new HelloViewModel { Name = "Anonim" });
        }

        [HttpPost]
        public IActionResult Hello(HelloViewModel helloViewModel)
        {
            if(ModelState.IsValid)
                return View(helloViewModel);
            return View(nameof(Index), helloViewModel);
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