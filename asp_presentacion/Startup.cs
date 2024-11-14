using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Comunicaciones
            services.AddScoped<IBodegasComunicacion, BodegasComunicacion>();
            services.AddScoped<IAccionesComunicacion, AccionesComunicacion>();
            services.AddScoped<IAuditoriasComunicacion, AuditoriasComunicacion>();
            services.AddScoped<ICategoriasComunicacion, CategoriasComunicacion>();
            services.AddScoped<IEstadosComunicacion, EstadosComunicacion>();
            services.AddScoped<IEstantesComunicacion, EstantesComunicacion>();
            services.AddScoped<ILotesComunicacion, LotesComunicacion>();
            services.AddScoped<IProductosComunicacion, ProductosComunicacion>();
            services.AddScoped<IProveedoresComunicacion, ProveedoresComunicacion>();
            services.AddScoped<IRolesComunicacion, RolesComunicacion>();
            services.AddScoped<ISucursalesComunicacion, SucursalesComunicacion>();
            services.AddScoped<IUsuariosComunicacion, UsuariosComunicacion>();
            services.AddScoped<ILoginComunicacion, LoginComunicacion>();

            // Presentaciones
            services.AddScoped<IBodegasPresentacion, BodegasPresentacion>();
            services.AddScoped<IAccionesPresentacion, AccionesPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();
            services.AddScoped<IEstadosPresentacion, EstadosPresentacion>();
            services.AddScoped<IEstantesPresentacion, EstantesPresentacion>();
            services.AddScoped<ILotesPresentacion, LotesPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<ISucursalesPresentacion, SucursalesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddScoped<ILoginPresentacion, LoginPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Login", ""));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddControllersWithViews();

            // Configura la autenticación de cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; // La cookie no es accesible desde JavaScript
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Usa cookies seguras (HTTPS)
                options.Cookie.SameSite = SameSiteMode.Strict; // Previene el envío de cookies en solicitudes de terceros
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // Duración de la cookie
                options.LoginPath = "/Login"; // Ruta de inicio de sesión
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}