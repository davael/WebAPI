using System;
using APITienda.Data;
using APITienda.Models;
using APITienda.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APITienda.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly ApplicationDbContext _bd;

        public PersonaRepository(ApplicationDbContext bd) : base(bd)
        {
            _bd = bd;
        }

        public async Task<bool> ExistePersona(string tipoDocumento, string numeroDocumento) =>
                    await _bd.Persona.AnyAsync(c => string.Equals(c.TipoDoc, tipoDocumento, StringComparison.CurrentCultureIgnoreCase) && string.Equals(c.NroDoc, numeroDocumento, StringComparison.CurrentCultureIgnoreCase));

        public async Task<Persona> GetPersona(string tipoDocumento, string numeroDocumento) =>
                    await _bd.Persona.FirstOrDefaultAsync(c => String.Equals(c.TipoDoc, tipoDocumento, StringComparison.CurrentCultureIgnoreCase) && String.Equals(c.NroDoc, numeroDocumento, StringComparison.CurrentCultureIgnoreCase));
    }
}
