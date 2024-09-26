using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class BodegasRepositorio : IBodegasRepositorio
    {
        private Conexion? conexion;

        public BodegasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Bodegas> Listar()
        {
            return conexion!.Listar<Bodegas>();
        }

        public List<Bodegas> Buscar(Expression<Func<Bodegas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Bodegas Guardar(Bodegas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Bodegas Modificar(Bodegas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Bodegas Borrar(Bodegas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Bodegas, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}