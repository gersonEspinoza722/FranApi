using System.Collections.Generic;
using System.Threading.Tasks;
using FranChallenge.Dtos;
using FranChallenge.Models;
using FranChallenge.Services.Interfaces;

namespace FranChallenge.Services
{
    public interface IOfficeService : IService<Office, GetOfficeDto>
    {
    }
}