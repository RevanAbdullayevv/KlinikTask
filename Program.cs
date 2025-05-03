using ClinicMVCProject.DAL;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            string connectionstr= "Server=RAVAN\\SQLEXPRESS;Database=ClinicDb;Trusted_Connection=True;TrustServercertificate=True";
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(connectionstr));
            
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute
            (
                name: "Default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
