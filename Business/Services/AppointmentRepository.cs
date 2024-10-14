using AutoMapper;
using HospitalManagementSystem.Business.Interfaces;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Entities;
using HospitalManagementSystem.Models.RequestModels;
using HospitalManagementSystem.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Business.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentRepository(ApplicationDbContext context, IMapper mapper, IDoctorRepository doctorRepository)
        {
            _context = context;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<CreateAppointmentResponseModel> CreateAppointment(CreateAppointmentRequestModel requestModel)
        {
            var appointment=_mapper.Map<Appointment>(requestModel);
            var doctor=await _doctorRepository.GetDoctorById(requestModel.DoctorId);
            appointment.Doctor = doctor;
            await _context.Appointments.AddAsync(appointment);
            if (await _context.SaveChangesAsync() > 0)
            {
                if (doctor.Patients!=null)
                {
                    doctor.Patients.Add(requestModel.PatientName);
                }
                else
                {
                    List<string> patientList = new List<string>();
                    patientList.Add(requestModel.PatientName);
                    doctor.Patients = patientList;
                }
                if(await _context.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<CreateAppointmentResponseModel>(appointment);
                }
                return null;
            }
            return null;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.Include("Doctor").ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByDoctorId(string patientName,int doctorId)
        {
            return await _context.Appointments.Include("Doctor").FirstOrDefaultAsync(x => x.DoctorId == doctorId && x.PatientName == patientName);
        }
    }
}
