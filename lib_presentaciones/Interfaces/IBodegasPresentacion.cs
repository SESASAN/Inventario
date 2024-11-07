using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IBodegasPresentacion
    {
        Task<List<Bodegas>> Listar();
        Task<List<Bodegas>> Buscar(Bodegas entidad, string tipo);
        Task<Bodegas> Guardar(Bodegas entidad);
        Task<Bodegas> Modificar(Bodegas entidad);
        Task<Bodegas> Borrar(Bodegas entidad);
    }
}
