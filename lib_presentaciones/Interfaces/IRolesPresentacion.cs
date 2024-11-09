using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IRolesPresentacion
    {
        Task<List<Roles>> Listar();
        Task<List<Roles>> Buscar(Roles entidad, string tipo);
        Task<Roles> Guardar(Roles entidad);
        Task<Roles> Modificar(Roles entidad);
        Task<Roles> Borrar(Roles entidad);
    }
}
