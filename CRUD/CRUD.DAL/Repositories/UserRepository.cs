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
            await connection.ExecuteAsync("INSERT INTO [Users](FirstName, LastName, Email) VALUES(@FName, @LName, @Email)", entity);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            var users = await connection.QueryAsync<UserEntity>("SELECT * FROM [Users]");
            
            return users;
        }

        public async Task DeleteAsync(int userId)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            await connection.ExecuteAsync("DELETE FROM [Users] WHERE UserId = @Id", new { Id = userId });
        }

        public async Task<UserEntity> UpdateAsync(UserEntity entity)
        { 
            var connection = new SqlConnection(_configuration.GetConnectionString("MSSQL"));
            await connection.ExecuteAsync("UPDATE [Users] SET FirstName = @FName, LastName = @LName, Email = @Email", entity);

            return entity;
        }
    }
}