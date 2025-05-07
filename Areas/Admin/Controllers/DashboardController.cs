using ClinicMVCProject.DAL;
using ClinicMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.Include(d => d.Doctors).ToList();
            return View(departments);
        }
    }
}
