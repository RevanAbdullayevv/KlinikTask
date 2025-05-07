using Microsoft.AspNetCore.Mvc;

namespace ClinicMVCProject.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
