using Microsoft.AspNetCore.Mvc;
using Small_task.Models;
using Small_task.ViewModels;
using System.Diagnostics;

namespace Small_task.Controllers
{
    public class HelloControllerVitalik : Controller
    {
        private readonly ILogger<HelloControllerVitalik> _logger;

        public HelloControllerVitalik(ILogger<HelloControllerVitalik> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new HelloCreateViewModel { Name = "Anonim" });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HelloCreateViewModel helloViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(nameof(Index), helloViewModel);
            }
            return View(helloViewModel);
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