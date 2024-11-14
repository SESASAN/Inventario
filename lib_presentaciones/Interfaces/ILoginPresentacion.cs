using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ILoginPresentacion
    {
        Task<string> Autenticar(Usuarios entidad);

    }
}
