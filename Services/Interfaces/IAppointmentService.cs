using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;

namespace FranChallenge.Services
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();
        Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int id);
        Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(Appointment appointment);
        Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(Appointment appointment);
        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(Appointment appointment);
    
    }
}