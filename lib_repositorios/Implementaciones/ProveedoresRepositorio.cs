using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ProveedoresRepositorio : IProveedoresRepositorio
    {
        private Conexion? conexion;

        public ProveedoresRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Proveedores> Listar()
        {
            return conexion!.Listar<Proveedores>();
        }

        public List<Proveedores> Buscar(Expression<Func<Proveedores, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Proveedores Modificar(Proveedores entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Proveedores, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}