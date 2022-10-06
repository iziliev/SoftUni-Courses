using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            return View();
        }
    }
}