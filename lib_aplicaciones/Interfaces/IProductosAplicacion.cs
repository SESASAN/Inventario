using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IProductosAplicacion
    {
        List<Productos> Listar();
        List<Productos> Buscar(Productos entidad, string tipo);
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}

