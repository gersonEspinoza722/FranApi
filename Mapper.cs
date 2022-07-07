using AutoMapper;
using FranChallenge.Dtos;
using FranChallenge.Models;
using FranChallenge.Services;

namespace FranChallenge
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Patient, GetPatientDto>();
            CreateMap<Office, GetOfficeDto>();
            CreateMap<Doctor, GetDoctorDto>();
            CreateMap<Appointment, GetAppointmentDto>();
        }
    }
}