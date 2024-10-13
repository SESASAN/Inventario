using lib_utilidades;
using Newtonsoft.Json;
namespace asp_servicios.Nucleo
{
    public class Configuracion
    {
        private static Dictionary<string, string>? datos = null;
        public static string ObtenerValor(string clave)
        {
            string respuesta = "";
            if (datos == null)
                Cargar();
            respuesta = datos![clave].ToString();
            return respuesta;
        }
        public static void Cargar()
        {
            datos = new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json);
            var json = jsonStream.ReadToEnd();
            var temp = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)!;
            foreach (var elemeto in temp) 
                datos[elemeto.Key] = elemeto.Value;
        }
    }
}
