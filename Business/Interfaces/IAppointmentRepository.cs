using HospitalManagementSystem.Models.Entities;
using HospitalManagementSystem.Models.RequestModels;
using HospitalManagementSystem.Models.ResponseModels;

namespace HospitalManagementSystem.Business.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentByDoctorId(string patientName, int doctorId);
        Task<CreateAppointmentResponseModel> CreateAppointment(CreateAppointmentRequestModel requestModel);
    }
}
