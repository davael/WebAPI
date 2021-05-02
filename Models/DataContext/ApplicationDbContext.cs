using APITienda.Models;
using Microsoft.EntityFrameworkCore;


namespace APITienda.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {

        }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
