using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ISucursalesPresentacion
    {
        Task<List<Sucursales>> Listar(string token);
        Task<List<Sucursales>> Buscar(Sucursales entidad, string tipo, string token);
        Task<Sucursales> Guardar(Sucursales entidad, string token);
        Task<Sucursales> Modificar(Sucursales entidad, string token);
        Task<Sucursales> Borrar(Sucursales entidad, string token);
    }
}