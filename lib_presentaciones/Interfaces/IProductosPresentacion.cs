using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IProductosPresentacion
    {
        Task<List<Productos>> Listar(string token);
        Task<List<Productos>> Buscar(Productos entidad, string tipo, string token);
        Task<Productos> Guardar(Productos entidad, string token);
        Task<Productos> Modificar(Productos entidad, string token);
        Task<Productos> Borrar(Productos entidad, string token);
    }
}
