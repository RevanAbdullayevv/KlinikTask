using ClinicMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVCProject.DAL;

public class AppDbContext:DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
    {
        
    }
}
