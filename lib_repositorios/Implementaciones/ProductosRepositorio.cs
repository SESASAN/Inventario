using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private Conexion? conexion;

        public ProductosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Productos> Listar()
        {
            return conexion!.Listar<Productos>();
        }

        public List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Productos Guardar(Productos entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Productos Modificar(Productos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Productos, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}