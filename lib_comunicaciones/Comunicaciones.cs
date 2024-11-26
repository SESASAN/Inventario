using lib_utilidades;
using System.Text.Json.Serialization;

namespace lib_comunicaciones
{
    public class Comunicaciones
    {
        public string? Protocolo = "http://",//es el tipo de url que se usa normalmente es http o https pero el S pide certificados y eso
            Host = "localhost:5283",//nombre del servidor depende de cada servidor
            Servicio = "",// "asp_notas_servicios/",//esto se pone cuando se publica en el IIS pero como no hay IIS se deja vacia
            Nombre = string.Empty,//nombre de la enidad controlador 
            Final = string.Empty,
            token = "";

        public Comunicaciones(string nombre)
        {
            Nombre = nombre;
        }

        public Comunicaciones()
        {
        }

        public Dictionary<string, object> BuildUrl(Dictionary<string, object> data, string Metodo)
        {
            data["Url"] = Protocolo + Host + "/" + Servicio + Nombre + "/" + Metodo + Final;
            return data;
        }

        public async Task<Dictionary<string, object>> Execute(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {

                var url = datos["Url"].ToString();
                datos.Remove("Url");
                this.token = datos["Token"].ToString();
                datos.Remove("Token");
                datos["Bearer"] = Replace(token!);
                var stringData = JsonConversor.ConvertirAString(datos);//el json conversor convierte el diccionacrio a string y porque el diccionario solo lo entiende el C# o codigo
                //NOTA: LOS SERVICIOS POR MADURES MANDA CODIGOS SI ES DE LA 200 a 299 es ok si es 300 a 399 es que falla algo para nosotros siempre va a ser 200 pq llegara el json con el error
                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);

                var message = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;

                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        // CAMBIAR AUTENTICAR, este es el que sirve para el login momentaneamente
        // EL CAMIBO ES EL BUILDURL O VER SI ESTÁ BIEN PLANETEADO
        public async Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                datos["UrlToken"] = Protocolo + Host + "/" + Servicio + "Token/Autenticar" + Final;
                var url = datos["UrlToken"].ToString();
                var temp = new Dictionary<string, object>();
                temp["Usuario"] = datos["Usuario"].ToString()!;
                temp["Clave"] = datos["Clave"].ToString()!;
                var stringData = JsonConversor.ConvertirAString(temp);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 1, 0);
                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await mensaje.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }

                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
               this.token = respuesta["Token"].ToString();

                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
        private string Replace(string resp)//remplaza cosas malas que puede traer el json como primero mandar un " y luego un ' este lo rempalaza para que no salga error
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}