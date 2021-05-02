using APITienda.Data;
using APITienda.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITienda.Repository
{
    /// <summary>
    /// Repositorio generico con las 4 operaciones elementales de todas las clases
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _bd;

        public GenericRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _bd.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _bd.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            try
            {
                var save = await _bd.Set<T>().AddAsync(entity);

                if (save != null)
                {


                    created = true;
                    await _bd.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }
        public async Task<bool> UpdateAsync(int id, T entity)
        {
            _bd.Set<T>().Update(entity);
            await _bd.SaveChangesAsync();
            return true;

        }
    }
}
