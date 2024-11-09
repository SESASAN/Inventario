using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion
    {
        Task<List<Auditorias>> Listar();
        Task<List<Auditorias>> Buscar(Auditorias entidad, string tipo);
        Task<Auditorias> Guardar(Auditorias entidad);
        
    }
}
