using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class AccionesRepositorio : IAccionesRepositorio
    {
        private Conexion? conexion = null;

        public AccionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Acciones> Listar()
        {
            return conexion!.Listar<Acciones>();
        }

        public List<Acciones> Buscar(Expression<Func<Acciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Acciones Guardar(Acciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Acciones Buscar(Acciones entidad)
        {
            conexion!.Buscar<Acciones>(x => x.Id != entidad!.Id);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Acciones Modificar(Acciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Acciones Borrar(Acciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Acciones, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}