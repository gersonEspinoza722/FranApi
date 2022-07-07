using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;
using FranChallenge.Services;
using FranChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FranChallenge.Controllers
{
    public class OfficeController : GenericController<Office, GetOfficeDto>
    {

        public OfficeController(IService<Office, GetOfficeDto> service) : base(service)
        {
        }
    }
}