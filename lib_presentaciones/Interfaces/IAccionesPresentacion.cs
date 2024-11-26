using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IAccionesPresentacion
    {
        Task<List<Acciones>> Listar(string token);
        Task<List<Acciones>> Buscar(Acciones entidad, string tipo, string token);
        Task<Acciones> Guardar(Acciones entidad, string token);
        Task<Acciones> Modificar(Acciones entidad, string token);
        Task<Acciones> Borrar(Acciones entidad, string token);
    }
}
