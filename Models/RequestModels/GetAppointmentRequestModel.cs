namespace HospitalManagementSystem.Models.RequestModels
{
    public class GetAppointmentRequestModel
    {
        public string patientName { get; set; }
        public int doctorId { get; set; }
    }
}
