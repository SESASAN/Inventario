using lib_entidades.Modelos;
using System.Net.NetworkInformation;

namespace mst_comunicaciones.Nucleo
{
    public class EntidadesHelper
    {
        public static Sucursales ObtenerSucursales()
        {
            return new Sucursales()
            {
                Nombre = "ZA Secundaria",
                Direccion = "Calle 46 #45-67",
            };
        }
        public static Proveedores ObtenerProveedores()
        {
            return new Proveedores()
            {
                Nombre = "Edgar Miranda",
                Direccion = "Calle 26 #75-76",
                Telefono = "3127673596",
            };
        }
        public static Estados ObtenerEstados()
        {
            return new Estados()
            {
                Nombre = "Test Estado"
            };
        }
        public static Bodegas ObtenerBodegas()
        {
            return new Bodegas()
            {
                Nombre = "Bodega UnitTest",
                Cantidad_estante = 1200,
                Valor_bodega = 120000.45m,
                Sucursal = 1,
            };
        }
        public static Categorias ObtenerCategorias()
        {
            return new Categorias()
            {
                Nombre = "Carnes",
            };
        }
        public static Estantes ObtenerEstantes()
        {
            return new Estantes()
            {
                Nombre = "Estante UnitTest",
                Cantidad_producto = 4,
                Bodega = 1,
                Categoria = 1,
                Valor = 1009.56m,
            };
        }
        public static Productos ObtenerProductos()
        {
            return new Productos()
            {
                Nombre = "Pan Integral",
                Descripcion = "7mil panes",
                Stock = 500,
                Precio_venta = 4800.23m,
                Iva = 0.19m,
                Estante = 1,
                Categoria = 1,
            };
        }
        public static Lotes ObtenerLotes()
        {
            return new Lotes()
            {
                Nombre = "Lote UnitTest",
                Producto = 1,
                Fecha_llegada = DateTime.Today,
                Fecha_vencimiento = DateTime.Now,
                Cantidad = 500,
                Precio_unitario = 12000m,
                Estado = 1,
                Proveedor = 1,
            };
        }

        public static Roles ObtenerRoles()
        {
            return new Roles()
            {
                Nombre = "RolPrueba",
                Permiso = false,
            };
        }
        public static Usuarios ObtenerUsuarios()
        {
            return new Usuarios()
            {
                Nombre_Usuario = "Usuario UnitTest",
                Nombre = "UsuarioPrueba",
                Apellidos = "Usuario UnitTest",
                Clave = "f12321321",
                Rol = 2,
            };
        }
        public static Acciones ObtenerAcciones()
        {
            return new Acciones()
            {
                Nombre = "AccionPrueba",
            };
        }

    }
}