using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FranChallenge.Data;
using FranChallenge.Dtos;
using FranChallenge.Models;

using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace FranChallenge.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public OfficeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetOfficeDto>>> Add(Office office)
        {
            var serviceResponse = new ServiceResponse<List<GetOfficeDto>>();
            office.id = _context.Offices.Count()+1;
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Offices.Select(c => _mapper.Map<GetOfficeDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOfficeDto>>> Delete(Office office)
        {
            var serviceResponse = new ServiceResponse<List<GetOfficeDto>>();
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Offices.Select(c => _mapper.Map<GetOfficeDto>(c)).ToList();
            return serviceResponse;        
        }

        public async Task<ServiceResponse<List<GetOfficeDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetOfficeDto>>();
            var dbOffice = await _context.Offices.ToListAsync();
            serviceResponse.Data = dbOffice.Select(c => _mapper.Map<GetOfficeDto>(c)).ToList();
            return serviceResponse;        }

        public async Task<ServiceResponse<GetOfficeDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOfficeDto>();
            var dbOffice = await _context.Offices.FirstOrDefaultAsync(x => x.id == id);
            serviceResponse.Data = _mapper.Map<GetOfficeDto>(dbOffice);
            return serviceResponse;        
        }

        public async Task<ServiceResponse<GetOfficeDto>> Update(Office office)
        {
            var serviceResponse = new ServiceResponse<GetOfficeDto>();
            var dbOffice = await _context.Offices.FirstOrDefaultAsync(x => x.id == office.id);
            dbOffice.officeNumber = office.officeNumber;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetOfficeDto>(dbOffice);
            return serviceResponse;        
        }
    }
}