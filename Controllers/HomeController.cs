using ClinicMVCProject.DAL;
using ClinicMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        List<Doctor> Doctors = _context.Doctors.Include(d=>d.Department).ToList();
        return View(Doctors);
    }
}
