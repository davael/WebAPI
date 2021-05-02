using System;
using System.IO;
using System.Reflection;
using APITienda.Data;
using APITienda.Mapper;
using APITienda.Repository;
using APITienda.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
namespace APITienda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

   
            services.AddAutoMapper(typeof(MiMapper));

            AddAllScoped(services);

            AddDB(services);

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/ApiClinica/swagger.json", "API Clinica");
            });


            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Crea la Conexion a la BD
        /// </summary>
        /// <param name="services"></param>
        private void AddDB(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("Conexion")));
        }

        
        /// <summary>
        /// Agrega Swagger al proyecto.
        /// </summary>
        /// <param name="services"></param>
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ApiClinica", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title="API Clinica",
                    Version= "1",
                    Description= "Backend Clinica",
                    Contact= new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email="dacisneros5@hotmail.com",
                        Name ="Damian Cisneros"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name="MIT License",
                    }
                });

                var archivoXmlComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
                options.IncludeXmlComments(rutaComentarios);
            });
        }
    
        /// <summary>
        /// Incorpora scoped entre Repositorios e Interfaces
        /// </summary>
        /// <param name="services"></param>
        private void AddAllScoped (IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPersonaRepository, PersonaRepository>();
        }
    }
}
