using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FranChallenge.Data;
using FranChallenge.Models;
using FranChallenge.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FranChallenge.Services
{
    public class GenericService<TEntity, TDto> : IService<TEntity, TDto>
    where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public GenericService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<TDto>>> Add(TEntity entity)
        {
            var serviceResponse = new ServiceResponse<List<TDto>>();
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Set<TEntity>().Select(c => _mapper.Map<TDto>(c)).ToList();
            return serviceResponse;        
        }

        public async Task<ServiceResponse<List<TDto>>> Delete(TEntity entity)
        {
            var serviceResponse = new ServiceResponse<List<TDto>>();
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Set<TEntity>().Select(c => _mapper.Map<TDto>(c)).ToList();
            return serviceResponse;        }

        public async Task<ServiceResponse<List<TDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<TDto>>();
            var dbOffice = await _context.Set<TEntity>().ToListAsync();
            serviceResponse.Data = dbOffice.Select(c => _mapper.Map<TDto>(c)).ToList();
            return serviceResponse;            
        }

        public async Task<ServiceResponse<TDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<TDto>();
            var dbEntity = _context.Set<TEntity>().GetByIdNew(id);
            serviceResponse.Data = _mapper.Map<TDto>(dbEntity);
            return serviceResponse;
        }

        public async Task<ServiceResponse<TDto>> Update(TEntity entity)
        {
            var serviceResponse = new ServiceResponse<TDto>();
            if (entity is Person && entity != null)
            {
                var person = entity as Person;
                var dbEntity = _context.Set<TEntity>().GetByIdNew(person.id);
                var record = dbEntity as Person;
                record.name = person.name;
                serviceResponse.Data = _mapper.Map<TDto>(dbEntity);
            }
            await _context.SaveChangesAsync();
            return serviceResponse;        
        }
    }
}