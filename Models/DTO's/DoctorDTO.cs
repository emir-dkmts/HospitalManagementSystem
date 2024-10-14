using HospitalManagementSystem.Helpers.Enums;

namespace HospitalManagementSystem.Models.DTO_s
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public List<string> Patients { get; set; }
    }
}
