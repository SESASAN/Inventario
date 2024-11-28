using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_comunicaciones;
using lib_comunicaciones.Interfaces;
using lib_utilidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mst_comunicaciones.Nucleo
{
    public class TokenHelper
    {
        private Comunicaciones iComunicacion = null;
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private string Nombre_Usuario = "$S4aMu3L.r";
        private string Clave = "$Qu1R@z.+*";

        public TokenHelper()
        {
            iComunicacion = new Comunicaciones();
        }

        public async Task<string> Autenticar()
        {
            datos["Usuario"] = Nombre_Usuario!;
            datos["Clave"] = Clave!;

            var respuesta = await iComunicacion!.Authenticate(datos);
            var lista = respuesta["Token"].ToString();

            return lista!;
        }

        
}
}
