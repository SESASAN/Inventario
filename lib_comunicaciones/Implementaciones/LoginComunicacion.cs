using lib_comunicaciones.Interfaces;

namespace lib_comunicaciones.Implementaciones
{
    public class LoginComunicacion : ILoginComunicacion
    {
        private Comunicaciones? comunicaciones = null;
        private string? Nombre = "Login";
        //Esto garantiza que por cada accion pedida es un objeto nuevo 
        public LoginComunicacion()
        {
            comunicaciones = new Comunicaciones();
        }

        public async Task<Dictionary<string, object>> Autenticar(Dictionary<string, object> datos)
        {
            datos = await comunicaciones!.Authenticate(datos);
            return datos;
        }


    }
}