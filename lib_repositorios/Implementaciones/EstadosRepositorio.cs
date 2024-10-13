using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstadosRepositorio : IEstadosRepositorio
    {
        private Conexion? conexion = null;

        public EstadosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estados> Listar()
        {
            return conexion!.Listar<Estados>();
        }

        public List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estados Guardar(Estados entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Estados Buscar(Estados entidad)
        {
            conexion!.Buscar<Estados>(x => x.Id != entidad!.Id);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Estados Modificar(Estados entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Estados Borrar(Estados entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Estados, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}