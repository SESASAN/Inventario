using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IAccionesPresentacion
    {
        Task<List<Acciones>> Listar();
        Task<List<Acciones>> Buscar(Acciones entidad, string tipo);
        Task<Acciones> Guardar(Acciones entidad);
        Task<Acciones> Modificar(Acciones entidad);
        Task<Acciones> Borrar(Acciones entidad);
    }
}
