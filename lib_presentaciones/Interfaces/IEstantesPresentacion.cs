using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstantesPresentacion
    {
        Task<List<Estantes>> Listar();
        Task<List<Estantes>> Buscar(Estantes entidad, string tipo);
        Task<Estantes> Guardar(Estantes entidad);
        Task<Estantes> Modificar(Estantes entidad);
        Task<Estantes> Borrar(Estantes entidad);
    }
}