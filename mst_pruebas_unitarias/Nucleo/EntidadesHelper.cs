﻿using lib_entidades.Modelos;
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
                Cantidad_estante = 1200,
                Valor_bodega = 120000.45m,
                Sucursal = 1,
            };
        }
        public static Categorias ObtenerCategorias()
        {
            return new Categorias()
            {
                Id = 2,
                Nombre = "Carnes",
            };
        }
        public static Estantes ObtenerEstantes()
        {
            return new Estantes()
            {
                Id = 2,
                Cantidad_producto = 4,
                Bodega = 1,
                Categoria = 1,
                Valor = 1009.56m,
            };
        }
        public static Productos ObtenerProductos ()
        {
            return new Productos()
            {
                Id = 2,
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
                Id = 2,
                Producto = 1,
                Fecha_llegada = DateTime.Today,
                Fecha_vencimiento = DateTime.Now,                
                Cantidad = 500,
                Precio_unitario = 12000m,
                Estado = 1,
                Proveedor = 1,
            };
        }
    }
}