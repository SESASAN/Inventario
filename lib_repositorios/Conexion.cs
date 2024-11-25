using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public class Conexion : DbContext
    {
        private int tamaño = 20;
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Sucursales>? Sucursales { get; set; }
        protected DbSet<Bodegas>? Bodegas { get; set; }
        protected DbSet<Estantes>? Estantes { get; set; }
        protected DbSet<Categorias>? Categorias { get; set; }
        protected DbSet<Productos>? Productos { get; set; }
        protected DbSet<Estados>? Estados { get; set; }
        protected DbSet<Proveedores>? Proveedores { get; set; }
        protected DbSet<Lotes>? Lotes { get; set; }
        protected DbSet<Roles>? Roles { get; set; }
        protected DbSet<Usuarios>? Usuarios { get; set; }
        protected DbSet<Auditorias>? Auditorias { get; set; }
        protected DbSet<Acciones>? Acciones { get; set; }

        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>()
                .Take(tamaño)
                .ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }

        public virtual List<Bodegas> Buscar(Expression<Func<Bodegas, bool>> condiciones)
        {
            return this.Set<Bodegas>()
                .Include(x => x._Sucursal)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<Estantes> Buscar(Expression<Func<Estantes, bool>> condiciones)
        {
            return this.Set<Estantes>()
                .Include(x => x._Bodega)
                .Include(x => x._Categoria)
                .Where(condiciones)
                .ToList();
        }

        public virtual List<Lotes> Buscar(Expression<Func<Lotes, bool>> condiciones)
        {
            return this.Set<Lotes>()
                .Include(x => x._Producto)
                .Include(x => x._Proveedor)
                .Include(x => x._Estado)
                .Where(condiciones)
                .ToList();
        }

        public virtual List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones)
        {
            return this.Set<Productos>()
                .Include(x => x._Categoria)
                .Include(x => x._Estante)
                .Where(condiciones)
                .ToList();
        }
        public virtual List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones)
        {
            return this.Set<Usuarios>()
                .Include(x => x._Rol)
                .Where(condiciones)
                .ToList();
        }


        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}
