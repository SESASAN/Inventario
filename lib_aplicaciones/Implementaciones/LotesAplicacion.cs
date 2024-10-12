using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class LotesAplicacion : ILotesAplicacion
    {
        private ILotesRepositorio? iRepositorio = null;
        public LotesAplicacion(ILotesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public Lotes Borrar(Lotes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Lotes Guardar(Lotes entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbYaSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Lotes> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Lotes> Buscar(Lotes entidad, string tipo)
        {
            Expression<Func<Lotes, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "ID": condiciones = x => x.Id!.Equals(entidad.Id!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Lotes Modificar(Lotes entidad)
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

