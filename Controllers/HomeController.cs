using ClinicMVCProject.DAL;
using ClinicMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicMVCProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Doctor> Doctors = _context.Doctors.ToList();
        return View(Doctors);
    }
}
