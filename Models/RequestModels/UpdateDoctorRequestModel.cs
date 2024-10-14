using HospitalManagementSystem.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.RequestModels
{
    public class UpdateDoctorRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Branch Branch { get; set; }
        [Required]
        public List<string> Patients { get; set; }
    }
}
