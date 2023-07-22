﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);


        Task DeleteAsync(int userId);

        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetUserByIdAsync(int userId);
    }
}