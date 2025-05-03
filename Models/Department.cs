namespace ClinicMVCProject.Models
{
    public class Department:BaseModel
    {
        public string Title {  get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
