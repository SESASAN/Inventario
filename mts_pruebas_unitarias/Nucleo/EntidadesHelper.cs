using lib_entidades;
using System.Net.NetworkInformation;

namespace mst_pruebas_unitarias.Nucleo
{
    public class EntidadesHelper
    {
        public static Sucursales ObtenerSucursales()
        {
            return new Sucursales()
            {
                Id = 2,
                Nombre = "ZA Secundaria",
                Direccion = "Calle 46 #45-67",
            };
        }
        public static Proveedores ObtenerProveedores()
        {
            return new Proveedores()
            {
                Id = 5,
                Nombre = "Edgar Miranda",
                Direccion = "Calle 26 #75-76",
                Telefono = "3127673596",
            };
        }
        public static Estados ObtenerEstados()
        {
            return new Estados()
            {
                Id= 4,
                Nombre="Test Estado"
            };
        }
        public static Bodegas ObtenerBodegas()
        {
            return new Bodegas()
            {
                Id = 2,
                Cantidad = 1200,
                Valor_bodega = 12000000.45m,
                Sucursal = 1,
            };
        }
        public static Categorias ObtenerCategorias()
        {
            return new Categorias()
            {
                Id = 5,
                Nombre = "Carnes",
                Grupo = 2,
            };
        }
        public static Estantes ObtenerEstantes()
        {
            return new Estantes()
            {
                Id = 2,
                Producto = 1,
                Cantidad_producto = 4,
                Bodega = 1,
                Categoria = 1,
            };
        }
        public static Productos ObtenerProductos ()
        {
            return new Productos()
            {
                Id = 2,
                Nombre = "Pan Integral",
                Stock = 500,
                Fecha_llegada = DateTime.Now,
                Fecha_vencimiento = DateTime.Now,
                Precio_unitario = 4800.23m,
                Categoria = 1,
                Estado = 1,
                Proveedor = 4,
            };
        }
    }
}