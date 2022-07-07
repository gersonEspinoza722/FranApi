using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using System.Linq;
using AutoMapper;
using FranChallenge.Data;
using FranChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace FranChallenge.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AppointmentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(Appointment appointment)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            appointment.id = _context.Appointments.Count()+1;
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Appointments.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;        
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(Appointment appointment)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Appointments.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointments = await _context.Appointments.ToListAsync();
            serviceResponse.Data = dbAppointments.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;        }

        public async Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var dbAppointment = await _context.Appointments.FirstOrDefaultAsync(x => x.id == id);
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            return serviceResponse;        }

        public async Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(Appointment appointment)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var dbAppointment = await _context.Appointments.FirstOrDefaultAsync(x => x.id == appointment.id);
            dbAppointment.office = appointment.office;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            return serviceResponse;        }
    }
}