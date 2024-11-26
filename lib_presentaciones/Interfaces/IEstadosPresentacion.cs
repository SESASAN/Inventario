using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstadosPresentacion
    {
        Task<List<Estados>> Listar(string token);
        Task<List<Estados>> Buscar(Estados entidad, string tipo, string token);
        Task<Estados> Guardar(Estados entidad, string token);
        Task<Estados> Modificar(Estados entidad, string token);
        Task<Estados> Borrar(Estados entidad, string token);
    }
}