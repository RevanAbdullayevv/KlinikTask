using ClinicMVCProject.DAL;
using ClinicMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.Include(d => d.Doctors).ToList();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            else
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Department? department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("Bu Department movcud deyil");
            }
            else
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Department? existingdepartment = _context.Departments.Find(id);
            if (existingdepartment == null)
            {
                return NotFound("Bu Department movcud deyil");
            }
            return View(nameof(Create), existingdepartment);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), department);
            }
            Department? existingDepartment = _context.Departments.AsNoTracking().FirstOrDefault(d=>d.Id == department.Id);
            if (existingDepartment == null)
            {
                return NotFound("Bu Department movcud deyil");
            }
            _context.Departments.Update(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
