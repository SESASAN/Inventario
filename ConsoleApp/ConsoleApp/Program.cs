using System;

public class Productos
{
    public Productos() { }

    private int id_Producto = 0;
    private string nombre = "";
    private int stock = 0;
    private DateTime fechaVencimiento;
    private double precioUnitario = 0.0;
    private Categorias? categoria = null;
    private Estados? estado = null;
    private Proveedores? proveedor = null;

    public int Id_Producto { get => this.id_Producto; set => this.id_Producto = value; }
    public string Nombre { get => this.nombre; set => this.nombre = value; }
    public int Stock { get => this.stock; set => this.stock = value; }
    public DateTime FechaVencimiento { get => this.fechaVencimiento; set => this.fechaVencimiento = value; }
    public double PrecioUnitario { get => this.precioUnitario; set => this.precioUnitario = value; }
    public Categorias? Categoria { get => this.categoria; set => this.categoria = value; }
    public Estados? Estado { get => this.estado; set => this.estado = value; }
    public Proveedores? Proveedor { get => this.proveedor; set => this.proveedor = value; }

}


public class Estantes
{
    public Estantes() { }

    private int id = 0;
    private Productos? producto = null;
    private Bodegas? bodega = null;
    private Categorias? categoria = null;
    private int cantidad_productos = 0;


    public int Id { get => this.id; set => this.id = value; }
    public Productos? Producto { get => this.producto; set => this.producto = value; }
    public Bodegas? Bodega { get => this.bodega; set => this.bodega = value; }
    public Categorias? Categoria { get => this.categoria; set => this.categoria = value; }
    public int Cantidad_productos { get => cantidad_productos; set => cantidad_productos = value; }

    public void calcularPrecioEstante() { }
}

public class Bodegas
{
    public Bodegas() { }

    private int id_bodega = 0;
    private DateTime fecha_llegada;
    private int cantidad = 0;
    private int valor_total = 0;

    public int Id_bodega { get => this.id_bodega; set => this.id_bodega = value; }
    public DateTime Fecha_llegada { get => this.fecha_llegada; set => this.fecha_llegada = value; }
    public int Cantidad { get => this.cantidad; set => this.cantidad = value; }
    public int Valor_total { get => this.valor_total; set => this.valor_total = value; }
    public void calcularPrecioBodega() { }

}

public class Sucursales
{
    public Sucursales() { }

    private int id_sucursal = 0;
    private Bodegas? bodega = null;
    private string nombre = "";
    private string direccion = "";


    public int Id_sucursal { get => this.id_sucursal; set => this.id_sucursal = value; }
    public Bodegas? Bodega { get => this.bodega; set => this.bodega = value; }
    public string Nombre { get => this.Nombre; set => this.Nombre = value; }
    public string Direccion { get => this.direccion; set => this.direccion = value; }
    public void calcularPrecioSucursal() { }
}

// Creamos la clase Categorías
public class Categorias
{
    public Categorias() { }
    /* Se hace uso del enum para poder especificar si la categoría que 
    vamos a usar es para la sección de los estantes o el tipo de producto*/
    public enum Grupos { PRODUCTO = 0, SECCION = 1 }

    // Se crea la id de la categoría
    private int id = 0;

    // Se crea la variable del nombre de la categoría
    private string nombre = "";

    // Se crea la variable del grupo que automaticamente se pone como default el grupo de Productos
    private int grupo = (int)Grupos.PRODUCTO;

    // Se crean los getters y setters de dichos atributos de la clase
    public int Id { get => this.id; set => this.id = value; }
    public string Nombre { get => this.nombre; set => this.nombre = value; }
    public int Grupo { get => this.grupo; set => this.grupo = value; }
}

public class Estados
{
    public Estados() { }

    private int id_Estado = 0;
    private string nombre = "";

    public string Nombre { get => this.nombre; set => this.nombre = value; }
    public int Id_Estado { get => this.id_Estado; set => this.id_Estado = value; }
}

public class Proveedores
{
    public Proveedores() { }

    private int id = 0;
    private string nombre = "";
    private string direccion = "";
    private string telefono = "";

    public int Id { get => this.id; set => this.id = value; }
    public string Nombre { get => this.nombre; set => this.nombre = value; }
    public string Direccion { get => this.direccion; set => this.direccion = value; }
    public string Telefono { get => this.telefono; set => this.telefono = value; }
}