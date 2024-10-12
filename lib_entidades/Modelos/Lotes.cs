using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Lotes
    {
        [Key] public int Id { get; set; }
        public int Producto { get; set; }
        public DateTime Fecha_llegada { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Estado { get; set; }
        public int Proveedor { get; set; }

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Proveedores? _Proveedor { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }


    }
}
