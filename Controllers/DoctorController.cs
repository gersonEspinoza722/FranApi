using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;
using FranChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace FranChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> GetAll()
        {
            return Ok(await _service.GetAllDoctors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDoctorDto>>> GetById(int id)
        {
            return Ok(await _service.GetDoctorById(id));
        }

        [HttpPost("AddDoctor")]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> Add(Doctor doctor)
        {
            return Ok(await _service.AddDoctor(doctor));
        }

        [HttpDelete("DeleteDoctor")]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> Delete(Doctor doctor)
        {
            return Ok(await _service.DeleteDoctor(doctor));
        }

        [HttpPut("UpdateDoctor")]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> Put(Doctor doctor)
        {
            var response = await _service.UpdateDoctor(doctor);
            if (response == null) {
                return NotFound(response);
            }
            return Ok(response);
        }


    }
}