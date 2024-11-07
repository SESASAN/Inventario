using lib_comunicaciones.Interfaces;

namespace lib_comunicaciones.Implementaciones
{
    public class ProductosComunicacion : IProductosComunicacion
    {
        private Comunicaciones? comunicaciones = null;
        private string? Nombre = "Productos";
        //Esto garantiza que por cada accion pedida es un objeto nuevo 
        public ProductosComunicacion()
        {
            comunicaciones = new Comunicaciones(Nombre);
        }

        public async Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Guardar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Buscar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Listar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Modificar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Borrar");
            return await comunicaciones!.Execute(datos);
        }
    }
}
