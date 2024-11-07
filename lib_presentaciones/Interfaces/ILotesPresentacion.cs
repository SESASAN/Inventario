using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ILotesPresentacion
    {
        Task<List<Lotes>> Listar();
        Task<List<Lotes>> Buscar(Lotes entidad, string tipo);
        Task<Lotes> Guardar(Lotes entidad);
        Task<Lotes> Modificar(Lotes entidad);
        Task<Lotes> Borrar(Lotes entidad);
    }
}