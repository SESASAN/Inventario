using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstadosPresentacion
    {
        Task<List<Estados>> Listar();
        Task<List<Estados>> Buscar(Estados entidad, string tipo);
        Task<Estados> Guardar(Estados entidad);
        Task<Estados> Modificar(Estados entidad);
        Task<Estados> Borrar(Estados entidad);
    }
}