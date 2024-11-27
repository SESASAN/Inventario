using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using System.Reflection;

namespace lib_presentaciones.Implementaciones
{
    public class AuditoriasPresentacion : IAuditoriasPresentacion
    {
        private IAuditoriasComunicacion? iComunicacion = null;

        public AuditoriasPresentacion(IAuditoriasComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<List<Auditorias>> Listar(string token)
        {
            var lista = new List<Auditorias>();
            var datos = new Dictionary<string, object>();
            datos["Token"] = token;

            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Auditorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Auditorias>> Buscar(Auditorias entidad, string tipo, string token)
        {
            var lista = new List<Auditorias>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;
            datos["Token"] = token;

            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Auditorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Auditorias> Guardar<T>(Auditorias entidad, string token, T enti)
        {
            if (entidad.Id != 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }
            List<string> lista = new List<string>();

            PropertyInfo[] propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {
                string nombre = propiedad.Name;
                object valor = propiedad.GetValue(enti)!;

                lista.Add($"{nombre}:{valor}");
            }
            entidad.Entidad = $"Entidad: {typeof(T).Name}, " + string.Join(", ", lista);

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Token"] = token;

            var respuesta = await iComunicacion!.Guardar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Auditorias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}