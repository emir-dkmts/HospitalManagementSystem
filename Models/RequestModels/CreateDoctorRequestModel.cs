using HospitalManagementSystem.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.RequestModels
{
    public class CreateDoctorRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Branch Branch { get; set; }
    }
}
