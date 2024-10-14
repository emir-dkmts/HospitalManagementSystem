using AutoMapper;
using HospitalManagementSystem.Models.RequestModels;
using HospitalManagementSystem.Models.Entities;
using HospitalManagementSystem.Models.DTO_s;
using HospitalManagementSystem.Models.ResponseModels;
namespace HospitalManagementSystem.Helpers.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<CreateDoctorRequestModel, Doctor>();
            CreateMap<UpdateDoctorRequestModel, Doctor>();
            CreateMap<Doctor,CreateDoctorResponseModel>();
            CreateMap<Doctor,UpdateDoctorResponseModel>();
            CreateMap<CreateDoctorResponseModel,DoctorDTO>();
            CreateMap<UpdateDoctorResponseModel, DoctorDTO>();
            CreateMap<Doctor, DoctorDTO>().ForMember(dest=>dest.Branch, opt=>opt.MapFrom(src=>src.Branch.ToString()));
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<CreateAppointmentRequestModel, Appointment>();
            CreateMap<Appointment, CreateAppointmentResponseModel>();
            CreateMap<CreateAppointmentResponseModel, AppointmentDTO>();
        }
    }
}
