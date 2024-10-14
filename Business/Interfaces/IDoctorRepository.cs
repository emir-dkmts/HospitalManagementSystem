using HospitalManagementSystem.Models.DTO_s;
using HospitalManagementSystem.Models.RequestModels;
using HospitalManagementSystem.Models.ResponseModels;
using HospitalManagementSystem.Models.Entities;

namespace HospitalManagementSystem.Business.Interfaces
{
    public interface IDoctorRepository
    {
        Task<CreateDoctorResponseModel> AddDoctor(CreateDoctorRequestModel requestModel);
        void DeleteDoctor(Doctor doctor);
        Task<UpdateDoctorResponseModel> UpdateDoctor(UpdateDoctorRequestModel requestModel);
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
    }
}
