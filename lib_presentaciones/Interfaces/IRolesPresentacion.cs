using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IRolesPresentacion
    {
        Task<List<Roles>> Listar(string token);
        Task<List<Roles>> Buscar(Roles entidad, string tipo, string token);
        Task<Roles> Guardar(Roles entidad, string token);
        Task<Roles> Modificar(Roles entidad, string token);
        Task<Roles> Borrar(Roles entidad, string token);
    }
}
