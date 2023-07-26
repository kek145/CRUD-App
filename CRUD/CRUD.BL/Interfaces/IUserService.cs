using CRUD.Domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRUD.BL.Interfaces
{
    public interface IUserService
    {
        Task DeleteUserAsync(int userId);
        Task<UserEntity> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> CreateNewUserAsync(UserEntity entity);
        Task<UserEntity> UpdateUserAsync(UserEntity entity, int userId);
    }
}