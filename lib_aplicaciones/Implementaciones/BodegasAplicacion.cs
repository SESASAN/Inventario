using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class BodegasAplicacion : IBodegasAplicacion
    {
        private IBodegasRepositorio? iRepositorio = null;
        public BodegasAplicacion(IBodegasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Bodegas Borrar(Bodegas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeEliminó");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Bodegas Guardar(Bodegas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Bodegas> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Bodegas> Buscar(Bodegas entidad, string tipo)
        {
            Expression<Func<Bodegas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "ID": condiciones = x => x.Id!.Equals(entidad.Id!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Bodegas Modificar(Bodegas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}

