using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Domain.Entity;

namespace CRUD.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);


        Task DeleteAsync(int userId);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetUserByIdAsync(int userId);
        Task<T> UpdateAsync(T entity, int userId);
    }
}