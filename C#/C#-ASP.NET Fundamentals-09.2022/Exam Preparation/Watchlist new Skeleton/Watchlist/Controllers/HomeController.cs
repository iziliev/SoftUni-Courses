using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
            }

            return View();
        }
    }
}