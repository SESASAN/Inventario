namespace lib_comunicaciones.Interfaces
{
    public interface IUsuariosComunicacion
    {
        Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos);
    }
}