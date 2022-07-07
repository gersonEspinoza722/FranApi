using System.Threading.Tasks;
using System.Collections.Generic;
using FranChallenge.Dtos;
using FranChallenge.Models;

namespace FranChallenge.Services
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<GetPatientDto>>> GetAll();
        Task<ServiceResponse<GetPatientDto>> GetById(int id);
        Task<ServiceResponse<List<GetPatientDto>>> Add(Patient patient);
        Task<ServiceResponse<List<GetPatientDto>>> Delete(Patient patient);
        Task<ServiceResponse<GetPatientDto>> Update(Patient patient);
    }
}