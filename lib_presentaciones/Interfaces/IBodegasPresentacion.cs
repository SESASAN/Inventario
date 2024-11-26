using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IBodegasPresentacion
    {
        Task<List<Bodegas>> Listar(string token);
        Task<List<Bodegas>> Buscar(Bodegas entidad, string tipo, string token);
        Task<Bodegas> Guardar(Bodegas entidad, string token);
        Task<Bodegas> Modificar(Bodegas entidad, string token);
        Task<Bodegas> Borrar(Bodegas entidad, string token);
    }
}
