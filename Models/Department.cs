using System.ComponentModel.DataAnnotations;

namespace ClinicMVCProject.Models
{
    public class Department:BaseModel
    {
        [Required,MinLength(3),MaxLength(20)]
        public string Title {  get; set; }
        public ICollection<Doctor>?Doctors { get; set; }
    }
}
