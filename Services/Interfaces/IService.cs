using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranChallenge.Services.Interfaces
{
    public interface IService<TEntity, TDto>
    {
        Task<ServiceResponse<List<TDto>>> GetAll();
        Task<ServiceResponse<TDto>> GetById(int id);
        Task<ServiceResponse<List<TDto>>> Add(TEntity entity);
        Task<ServiceResponse<List<TDto>>> Delete(TEntity entity);
        Task<ServiceResponse<TDto>> Update(TEntity entity);
    }
}