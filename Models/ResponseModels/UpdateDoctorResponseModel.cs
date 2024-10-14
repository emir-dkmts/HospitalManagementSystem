using HospitalManagementSystem.Helpers.Enums;

namespace HospitalManagementSystem.Models.ResponseModels
{
    public class UpdateDoctorResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch Branch { get; set; }
        public List<string> Patients { get; set; }
    }
}
