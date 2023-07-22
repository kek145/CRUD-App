using Dapper;
using CRUD.Domain.Entity;
using CRUD.DAL.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CRUD.DAL.Repositories
{
    public class UserRepository : IBaseRepository<UserEntity>
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task CreateAsync(UserEntity entity)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            await connection.ExecuteAsync("INSERT INTO Users(FirstName, LastName, Email) VALUES(@FName, @LName, @Email)",
                new { FName = entity.FirstName, LName = entity.LastName, Email = entity.Email });
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            var users = await connection.QueryAsync<UserEntity>("SELECT * FROM [Users]");
            
            return users;
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            var user = await connection.QueryFirstOrDefaultAsync<UserEntity>("SELECT * FROM [Users] WHERE UserId = @Id",
                new { Id = userId });

            return user;
        }

        public async Task DeleteAsync(int userId)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            await connection.ExecuteAsync("DELETE FROM [Users] WHERE UserId = @Id", new { Id = userId });
        }

        public async Task<UserEntity> UpdateAsync(UserEntity entity, int userId)
        { 
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            await connection.ExecuteAsync("UPDATE [Users] SET FirstName = @FName, LastName = @LName, Email = @Email WHERE UserId = @Id", 
                new {FName = entity.FirstName, LName = entity.LastName, Email = entity.Email, Id = userId});

            return entity;
        }
    }
}