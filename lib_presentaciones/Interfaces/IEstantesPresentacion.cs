using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstantesPresentacion
    {
        Task<List<Estantes>> Listar(string token);
        Task<List<Estantes>> Buscar(Estantes entidad, string tipo, string token);
        Task<Estantes> Guardar(Estantes entidad, string token);
        Task<Estantes> Modificar(Estantes entidad, string token);
        Task<Estantes> Borrar(Estantes entidad, string token);
    }
}