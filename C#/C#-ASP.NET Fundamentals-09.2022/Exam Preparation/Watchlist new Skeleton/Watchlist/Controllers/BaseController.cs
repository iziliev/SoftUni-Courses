using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public class Utilities
        {
            public static string ControllerName<T>() where T : Controller
            {
                var name = typeof(T).Name;
                return name.Substring(0, Math.Max(name.LastIndexOf(nameof(Controller),
                                                  StringComparison.CurrentCultureIgnoreCase), 0));
            }
        }
    }
}
