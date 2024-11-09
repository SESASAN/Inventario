namespace lib_comunicaciones.Interfaces
{
    public interface IAuditoriasComunicacion
    {
        Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos);
    }
}