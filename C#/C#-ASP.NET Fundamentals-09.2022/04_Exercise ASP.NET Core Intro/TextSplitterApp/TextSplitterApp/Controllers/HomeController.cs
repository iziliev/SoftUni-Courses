using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {

            var spplitedArray = model.InputText
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            model.SplitedText = string.Join(Environment.NewLine, spplitedArray);
            return RedirectToAction(nameof(Index),model);
        }

        public IActionResult Privacy(TextViewModel model)
        {
            ViewBag.Message = Request.Host.Value.ToString();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}