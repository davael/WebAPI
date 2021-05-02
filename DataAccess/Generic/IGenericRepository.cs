using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITienda.Repository.IRepository
{
    public interface IGenericRepository<T> where  T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id,T entity);

    }
}
