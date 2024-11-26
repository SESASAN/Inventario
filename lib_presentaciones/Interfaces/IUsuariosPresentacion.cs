using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<List<Usuarios>> Listar(string token);
        Task<List<Usuarios>> Buscar(Usuarios entidad, string tipo, string token);
        Task<Usuarios> Guardar(Usuarios entidad, string token);
        Task<Usuarios> Modificar(Usuarios entidad, string token);
        Task<Usuarios> Borrar(Usuarios entidad, string token);
    }
}
