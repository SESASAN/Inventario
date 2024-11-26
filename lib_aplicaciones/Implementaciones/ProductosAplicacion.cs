using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IProductosRepositorio? iRepositorio = null;
        public ProductosAplicacion(IProductosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id == 0)
                throw new Exception("lbNoSeEliminó");
            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }
        public Productos Guardar(Productos entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbNoSeGuardo");
            entidad.Precio_venta = entidad.CalcularPrecioVenta();
            //int venta = 0; //actualizar el valor de venta para que se actualice el stock con ese valor correspondiente
            //entidad.ActualizarStock(venta);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Productos> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Productos> Buscar(Productos entidad, string tipo)
        {
            Expression<Func<Productos, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }
        public Productos Modificar(Productos entidad)
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

