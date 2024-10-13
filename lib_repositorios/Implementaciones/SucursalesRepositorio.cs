using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class SucursalesRepositorio : ISucursalesRepositorio
    {
        private Conexion? conexion = null;

        public SucursalesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Sucursales> Listar()
        {
            return conexion!.Listar<Sucursales>();
        }

        public List<Sucursales> Buscar(Expression<Func<Sucursales, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Sucursales Buscar(Sucursales entidad)
        {
            conexion!.Buscar<Sucursales>(x => x.Id != entidad!.Id);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Sucursales Modificar(Sucursales entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Sucursales Borrar(Sucursales entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Sucursales, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}