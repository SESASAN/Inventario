using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion
    {
        Task<List<Auditorias>> Listar(string token);
        Task<List<Auditorias>> Buscar(Auditorias entidad, string tipo, string token);
        Task<Auditorias> Guardar(Auditorias entidad, string token);
        
    }
}
