using APITienda.Data;
using APITienda.Models;
using APITienda.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITienda.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly ApplicationDbContext _bd;

        public PersonaRepository(ApplicationDbContext bd): base (bd)
        {
            _bd = bd;
        }

        public async Task<bool> ExistePersona(string td, string nd)
        {
            return await _bd.Persona.AnyAsync(c => c.TipoDoc.ToLower() == td.ToLower() && c.NroDoc.ToLower() == nd.ToLower());
        }
        
        public async Task<Persona> GetPersona(string td, string nd)
        {
            return await _bd.Persona.FirstOrDefaultAsync(c => c.TipoDoc.ToLower() == td.ToLower() && c.NroDoc.ToLower() == nd.ToLower());
        }
    }
}
