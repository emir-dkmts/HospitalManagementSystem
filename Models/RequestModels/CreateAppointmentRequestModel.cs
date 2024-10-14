namespace HospitalManagementSystem.Models.RequestModels
{
    public class CreateAppointmentRequestModel
    {
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
    }
}
