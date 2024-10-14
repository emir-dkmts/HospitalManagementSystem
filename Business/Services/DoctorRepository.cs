using AutoMapper;
using HospitalManagementSystem.Business.Interfaces;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.DTO_s;
using HospitalManagementSystem.Models.RequestModels;
using HospitalManagementSystem.Models.ResponseModels;
using HospitalManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Business.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateDoctorResponseModel> AddDoctor(CreateDoctorRequestModel requestModel)
        {
            var doctor = _mapper.Map<Doctor>(requestModel);
            await _context.AddAsync(doctor);
            if (await _context.SaveChangesAsync() > 0)
            {
                return _mapper.Map<CreateDoctorResponseModel>(doctor);
            }
            return null;
        }

        public async void DeleteDoctor(Doctor doctor)
        {
            _context.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UpdateDoctorResponseModel> UpdateDoctor(UpdateDoctorRequestModel requestModel)
        {
            var doctor = _mapper.Map<Doctor>(requestModel);
            _context.Doctors.Update(doctor);
            if(await _context.SaveChangesAsync()>0)
            {
                return _mapper.Map<UpdateDoctorResponseModel>(doctor);
            }
            return null;
        }
    }
}
