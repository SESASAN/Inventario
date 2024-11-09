using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<List<Usuarios>> Listar();
        Task<List<Usuarios>> Buscar(Usuarios entidad, string tipo);
        Task<Usuarios> Guardar(Usuarios entidad);
        Task<Usuarios> Modificar(Usuarios entidad);
        Task<Usuarios> Borrar(Usuarios entidad);
    }
}
