using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;

namespace FranChallenge.Services
{
    public interface IDoctorService
    {
        Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctors();
        Task<ServiceResponse<GetDoctorDto>> GetDoctorById(int id);
        Task<ServiceResponse<List<GetDoctorDto>>> AddDoctor(Doctor doctor);
        Task<ServiceResponse<List<GetDoctorDto>>> DeleteDoctor(Doctor doctor);
        Task<ServiceResponse<GetDoctorDto>> UpdateDoctor(Doctor doctor);

    }
}