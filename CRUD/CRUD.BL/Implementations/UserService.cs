using CRUD.BL.Interfaces;
using CRUD.Domain.Entity;
using CRUD.DAL.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRUD.BL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public UserService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user;
        }

        public async void DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<UserEntity> UpdateUserAsync(UserEntity entity)
        {
            var user = await _userRepository.UpdateAsync(entity);
            return user;
        }

        public async Task<UserEntity> CreateNewUserAsync(UserEntity entity)
        {
            await _userRepository.CreateAsync(entity);
            return entity;
        }
    }
}