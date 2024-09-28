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
        public decimal Precio_unitario { get; set; }
        public int Categoria { get; set; }
        public int Estado { get; set; }
        public int Proveedor { get; set; }

        [NotMapped] public Categorias? _Categoria { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }
        [NotMapped] public Proveedores? _Proveedor { get; set; }

    }
}
