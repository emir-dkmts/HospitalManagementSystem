using HospitalManagementSystem.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Branch Branch { get; set; }
        public List<string>? Patients { get; set; }

    }
}
