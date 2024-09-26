using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_llegada { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public double Precio_unitario { get; set; }
        public Categorias? Categoria { get; set; }
        public Estados? Estado { get; set; }
        public Proveedores? Proveedor { get; set; }

        [NotMapped] public Categorias? _Categoria { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }
        [NotMapped] public Proveedores? _Proveedor { get; set; }

    }
}
