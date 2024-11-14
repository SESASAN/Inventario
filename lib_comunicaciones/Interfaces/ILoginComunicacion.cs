namespace lib_comunicaciones.Interfaces
{
    public interface ILoginComunicacion
    {
        Task<Dictionary<string, object>> Autenticar(Dictionary<string, object> datos);

    }
}