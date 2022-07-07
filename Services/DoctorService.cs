using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using System.Linq;
using AutoMapper;
using FranChallenge.Models;
using FranChallenge.Data;
using Microsoft.EntityFrameworkCore;

namespace FranChallenge.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DoctorService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> AddDoctor(Doctor doctor)
        {
            var serviceResponse = new ServiceResponse<List<GetDoctorDto>>();
            doctor.id = _context.Doctors.Count()+1;
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Doctors.Select(c => _mapper.Map<GetDoctorDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> DeleteDoctor(Doctor doctor)
        {
            var serviceResponse = new ServiceResponse<List<GetDoctorDto>>();
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Doctors.Select(c => _mapper.Map<GetDoctorDto>(c)).ToList();
            return serviceResponse;        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctors()
        {
            var serviceResponse = new ServiceResponse<List<GetDoctorDto>>();
            var dbDoctors = await _context.Doctors.ToListAsync();
            serviceResponse.Data = dbDoctors.Select(c => _mapper.Map<GetDoctorDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDoctorDto>> GetDoctorById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDoctorDto>();
            var dbDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.id == id);
            serviceResponse.Data = _mapper.Map<GetDoctorDto>(dbDoctor);
            return serviceResponse;
        }

        public async  Task<ServiceResponse<GetDoctorDto>> UpdateDoctor(Doctor doctor)
        {
            var serviceResponse = new ServiceResponse<GetDoctorDto>();
            var dbDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.id == doctor.id);
            dbDoctor.name = doctor.name;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDoctorDto>(dbDoctor);
            return serviceResponse;        
        }
    }
}