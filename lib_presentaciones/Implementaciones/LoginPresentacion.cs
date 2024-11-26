using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;

namespace lib_presentaciones.Implementaciones
{
    public class LoginPresentacion : ILoginPresentacion
    {
        private ILoginComunicacion? iComunicacion = null;

        public LoginPresentacion(ILoginComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<string> Autenticar(Usuarios entidad)
        {
            var datos = new Dictionary<string, object>();
            datos["Usuario"] = entidad.Nombre_Usuario!;
            datos["Clave"] = entidad.Clave!;

            var respuesta = await iComunicacion!.Autenticar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            var lista = respuesta["Token"].ToString();
            return lista!;
        }

    }
}