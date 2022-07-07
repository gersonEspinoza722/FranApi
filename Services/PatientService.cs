using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FranChallenge.Data;
using System.Linq.Expressions;
using System;

namespace FranChallenge.Services
{
    public class PatientService : IPatientService
    {


        
        private readonly DataContext _context;
        //private static List<Patient> patients = new List<Patient>(){
       //     new Patient{ name = "Javier" },
        //    new Patient{ name = "JAJAJA" },
       // };
        private readonly IMapper _mapper;

        public PatientService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> Add(Patient patient)
        {
            var serviceResponse = new ServiceResponse<List<GetPatientDto>>();
            patient.id = _context.Patients.Count()+1;
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Patients.Select(c => _mapper.Map<GetPatientDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> Delete(Patient patient)
        {
            var serviceResponse = new ServiceResponse<List<GetPatientDto>>();
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Patients.Select(c => _mapper.Map<GetPatientDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetPatientDto>>();
            var dbPatients = await _context.Patients.ToListAsync();
            serviceResponse.Data = dbPatients.Select(c => _mapper.Map<GetPatientDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPatientDto>();
            var dbPatient = _context.Patients.GetByIdNew(id);
            serviceResponse.Data = _mapper.Map<GetPatientDto>(dbPatient);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> Update(Patient patient)
        {
            var serviceResponse = new ServiceResponse<GetPatientDto>();
            var dbPatient = await _context.Patients.FirstOrDefaultAsync(x => x.id == patient.id);
            dbPatient.name = patient.name;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPatientDto>(dbPatient);
            return serviceResponse;
        }


    }
}