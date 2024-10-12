using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IProveedoresRepositorio? iRepositorio = null;
        public ProveedoresAplicacion(IProveedoresRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Proveedores Guardar(Proveedores entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbYaSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Proveedores> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Proveedores> Buscar(Proveedores entidad, string tipo)
        {
            Expression<Func<Proveedores, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Proveedores Modificar(Proveedores entidad)
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

