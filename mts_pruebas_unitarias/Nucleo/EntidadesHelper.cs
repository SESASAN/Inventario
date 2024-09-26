using lib_entidades;

namespace mst_pruebas_unitarias.Nucleo
{
    public class EntidadesHelper
    {
        public static Sucursales ObtenerSucursales()
        {
            return new Sucursales()
            {
                Id = 10,
                Nombre = "ZA Principal",
                Direccion = "Calle 46 #45-67",
            };
        }
    }
}