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
                Id = 10,
                Nombre = "ZA Principal",
                Direccion = "Calle 46 #45-67",
            };
        }
        public static Proveedores ObtenerProveedores()
        {
            return new Proveedores()
            {
                Id = 11,
                Nombre = "Edgar Miranda",
                Direccion = "Calle 26 #75-76",
                Telefono = "3127673596",
            };
        }
        public static Estados ObtenerEstados()
        {
            return new Estados()
            {
                Id= 12,
                Nombre="Próximo a vencer"
            };
        }
        public static Bodegas ObtenerBodegas()
        {
            return new Bodegas()
            {
                Id = 50,
                Cantidad = 1200,
                Valor_bodega = 1200.45m,
                Sucursal = 1,
            };
        }
        public static Categorias ObtenerCategorias()
        {
            return new Categorias()
            {
                Id = 15,
                Nombre = "Carnes",
                Grupo = 2,
            };
        }
        public static Estantes ObtenerEstantes()
        {
            return new Estantes()
            {
                Id = 30,
                Producto = 3,
                Cantidad_producto = 4,
                Bodega = 3,
                Categoria = 1,
            };
        }
        public static Productos ObtenerProductos ()
        {
            return new Productos()
            {
                Id = 56,
                Nombre = "Pan Integral",
                Stock = 500,
                Fecha_llegada = DateTime.Now,
                Fecha_vencimiento = DateTime.Now,
                Precio_unitario = 4800.23m,
                Categoria = 4,
                Estado = 1,
                Proveedor = 4,
            };
        }
    }
}