using AutoMapper;
using HospitalManagementSystem.Business.Interfaces;
using HospitalManagementSystem.Helpers.Enums;
using HospitalManagementSystem.Models.DTO_s;
using HospitalManagementSystem.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        public DoctorsController(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorRequestModel requestModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!Enum.IsDefined(typeof(Branch), requestModel.Branch))
            {
                return BadRequest("This branch value does not exists");
            }
            var responseModel=await _doctorRepository.AddDoctor(requestModel);
            if (responseModel == null)
            {
                return BadRequest("An error occured during creating ");
            }
            return Ok(_mapper.Map<DoctorDTO>(responseModel));
        }
        [HttpPut]
        [Route("UpdateDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorRequestModel requestModel)
        {
            if (!Enum.IsDefined(typeof(Branch), requestModel.Branch))
            {
                return BadRequest("This branch value does not exists");
            }
            var responseModel=await _doctorRepository.UpdateDoctor(requestModel);
            if (responseModel == null)
            {
                return BadRequest("An error occured during updating");
            }
            return Ok(_mapper.Map<DoctorDTO>(responseModel));
        }
        [HttpDelete]
        [Route("DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor([FromQuery] int id)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
            {
                return BadRequest("The doctor does not exists");  
            }
            _doctorRepository.DeleteDoctor(doctor);
            return Ok("The product has deleted");
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetDoctorById([FromQuery] int id)
        {
            var doctor= await _doctorRepository.GetDoctorById(id);
            if(doctor == null)
            {
                return BadRequest("The doctor does not exists");
            }
            return Ok(_mapper.Map<DoctorDTO>(doctor));
        }
    }
}
