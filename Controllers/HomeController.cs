using Microsoft.AspNetCore.Mvc;

namespace KlinikTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
