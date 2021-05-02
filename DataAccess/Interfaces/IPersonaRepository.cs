using APITienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITienda.Repository.IRepository
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<bool> ExistePersona(string td, string nd);

        Task<Persona> GetPersona(string td, string nd);
/*        
        Task<bool> CrearPersona(Persona per);
        Task<bool> ActualizarPersonaAsync(Persona per);
        Task<bool> GuardarAsync();
        */
    }
}
