using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using lib_repositorios;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IBodegasRepositorio, BodegasRepositorio>();
            services.AddScoped<ICategoriasRepositorio, CategoriasRepositorio>();
            services.AddScoped<IEstadosRepositorio, EstadosRepositorio>();
            services.AddScoped<IEstantesRepositorio, EstantesRepositorio>();
            services.AddScoped<ILotesRepositorio, LotesRepositorio>();
            services.AddScoped<IProductosRepositorio, ProductosRepositorio>();
            services.AddScoped<IProveedoresRepositorio, ProveedoresRepositorio>();
            services.AddScoped<ISucursalesRepositorio, SucursalesRepositorio>();
            services.AddScoped<IRolesRepositorio, RolesRepositorio>();
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IAuditoriasRepositorio, AuditoriasRepositorio>();
            services.AddScoped<IAccionesRepositorio, AccionesRepositorio>();
            // Aplicaciones
            services.AddScoped<IBodegasAplicacion, BodegasAplicacion>();
            services.AddScoped<ICategoriasAplicacion, CategoriasAplicacion>();
            services.AddScoped<IEstadosAplicacion, EstadosAplicacion>();
            services.AddScoped<IEstantesAplicacion, EstantesAplicacion>();
            services.AddScoped<ILotesAplicacion, LotesAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<ISucursalesAplicacion, SucursalesAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IAccionesAplicacion, AccionesAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}