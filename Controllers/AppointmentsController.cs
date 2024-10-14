using AutoMapper;
using HospitalManagementSystem.Business.Interfaces;
using HospitalManagementSystem.Models.DTO_s;
using HospitalManagementSystem.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentsRepository;
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentsController(IAppointmentRepository appointmentsRepository, IMapper mapper, IDoctorRepository doctorRepository)
        {
            _appointmentsRepository = appointmentsRepository;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments=await _appointmentsRepository.GetAllAppointments();
            return Ok(_mapper.Map<List<AppointmentDTO>>(appointments));
        }
        [HttpGet]
        [Route("GetAppointmentByIds")]
        public async Task<IActionResult> GetAppointmentByIds([FromBody] GetAppointmentRequestModel requestModel)
        {
            var appointment= await _appointmentsRepository.GetAppointmentByDoctorId(requestModel.patientName,requestModel.doctorId);
            if(appointment == null)
            {
                return NotFound("The appointment does not exists");
            }
            return Ok(_mapper.Map<AppointmentDTO>(appointment));
        }
        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody]CreateAppointmentRequestModel requestModel)
        {
            var doctor=await _doctorRepository.GetDoctorById(requestModel.DoctorId);
            if(doctor.Patients.Contains(requestModel.PatientName))
            {
                return BadRequest("The patient is already assigned to doctor");
            }
            if(doctor.Patients.Count() > 10)
            {
                return BadRequest("The doctor cannot take patients more than 10");
            }
            if(requestModel.AppointmentDate<DateTime.UtcNow.AddDays(3))
            {
                return BadRequest("The appointment date is invalid");
            }
            var response = await _appointmentsRepository.CreateAppointment(requestModel);
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<AppointmentDTO>(response));
        }
    }
}
