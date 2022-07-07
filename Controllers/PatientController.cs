using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;
using FranChallenge.Services;
using FranChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FranChallenge.Controllers
{
    public class PatientController : GenericController<Patient, GetPatientDto>
    {
        public PatientController(IService<Patient, GetPatientDto> service) : base(service)
        {
        }
    }
}