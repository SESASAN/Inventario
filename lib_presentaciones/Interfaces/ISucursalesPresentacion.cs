using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ISucursalesPresentacion
    {
        Task<List<Sucursales>> Listar();
        Task<List<Sucursales>> Buscar(Sucursales entidad, string tipo);
        Task<Sucursales> Guardar(Sucursales entidad);
        Task<Sucursales> Modificar(Sucursales entidad);
        Task<Sucursales> Borrar(Sucursales entidad);
    }
}