using ClinicMVCProject.DAL;
using ClinicMVCProject.Models;
using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _context.Doctors.Include(d => d.Department).ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (!doctor.ImageUpload.ContentType.Contains("image"))
            {
                ModelState.AddModelError("ImageUpload", "File must be image format");
                return View(doctor);
            }
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            string fileName = Guid.NewGuid() + doctor.ImageUpload.FileName;
            string path = @"C:\Users\rabdu\source\repos\ClinicMVCProject\ClinicMVCProject\wwwroot\UploadImages\Doctors\img\";
            using (FileStream fileStream = new FileStream(path+fileName, FileMode.Create))
            {
                doctor.ImageUpload.CopyTo(fileStream);
            }
            doctor.ImgUrl = fileName;
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Doctor? doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound("Bu Hekim movcud deyil");
            }
            else
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Doctor? existingdoctor = _context.Doctors.Find(id);
            if (existingdoctor == null)
            {
                return NotFound("Bu Hekim movcud deyil");
            }
            return View(nameof(Create), existingdoctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
           
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), doctor);
            }
            Doctor? existingDoctor = _context.Doctors.AsNoTracking().FirstOrDefault(d => d.Id == doctor.Id);
            if (existingDoctor == null)
            {
                return NotFound("Bu Hekim movcud deyil");
            }  
            if (doctor.ImageUpload.ContentType == null)
            {
                return View(nameof(Create),doctor);
            }
            string fileName = Guid.NewGuid() + doctor.ImageUpload.FileName;
            string path = @"C:\Users\rabdu\source\repos\ClinicMVCProject\ClinicMVCProject\wwwroot\UploadImages\Doctors\img\";
            using (FileStream fileStream = new FileStream(path + fileName, FileMode.Create))
            {
                doctor.ImageUpload.CopyTo(fileStream);
            }
            doctor.ImgUrl = fileName;
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
