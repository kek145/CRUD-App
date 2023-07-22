using CRUD.Domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRUD.BL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetUserByIdAsync(int userId);
        void DeleteUserAsync(int userId);
        Task<UserEntity> UpdateUserAsync(UserEntity entity);
        Task<UserEntity> CreateNewUserAsync(UserEntity entity);
    }
}