using HospitalManagementSystem.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.ResponseModels
{
    public class CreateDoctorResponseModel
    {
        public string Name { get; set; }
        public Branch Branch { get; set; }
        public List<string>? Patients { get; set; }
    }
}
