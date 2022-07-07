using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Services;
using FranChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FranChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController<TEntity, TDto> : ControllerBase where TEntity : class
    {
        private readonly IService<TEntity, TDto> _service;
        public GenericController(IService<TEntity, TDto> service)
        {
            _service=service;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TDto>>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> Add(TEntity entity)
        {
            return Ok(await _service.Add(entity));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> Delete(TEntity entity)
        {
            return Ok(await _service.Delete(entity));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TDto>>>> Put(TEntity entity)
        {
            var response = await _service.Update(entity);
            if (response == null) {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}