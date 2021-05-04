using APITienda.Data;
using APITienda.Repository;
using APITienda.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace APITienda.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Crea la Conexion a la BD
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddDB(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("Conexion"))
            );

        /// <summary>
        /// Agrega Swagger al proyecto.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ApiClinica", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "API Clinica",
                    Version = "1",
                    Description = "Backend Clinica",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "dacisneros5@hotmail.com",
                        Name = "Damian Cisneros"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT License",
                    }
                });

                var archivoXmlComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
                options.IncludeXmlComments(rutaComentarios);
            });

        /// <summary>
        /// Incorpora scoped entre Repositorios e Interfaces
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddAllScoped(this IServiceCollection services) =>
            services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IPersonaRepository, PersonaRepository>();
    }
}