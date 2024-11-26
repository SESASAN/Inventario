using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ILotesPresentacion
    {
        Task<List<Lotes>> Listar(string token);
        Task<List<Lotes>> Buscar(Lotes entidad, string tipo, string token);
        Task<Lotes> Guardar(Lotes entidad, string token);
        Task<Lotes> Modificar(Lotes entidad, string token);
        Task<Lotes> Borrar(Lotes entidad, string token);
    }
}