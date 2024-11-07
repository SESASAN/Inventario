using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IProductosPresentacion
    {
        Task<List<Productos>> Listar();
        Task<List<Productos>> Buscar(Productos entidad, string tipo);
        Task<Productos> Guardar(Productos entidad);
        Task<Productos> Modificar(Productos entidad);
        Task<Productos> Borrar(Productos entidad);
    }
}
