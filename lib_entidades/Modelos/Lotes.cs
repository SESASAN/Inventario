using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace lib_entidades.Modelos
{
    public class Lotes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Producto { get; set; }
        public DateTime Fecha_llegada { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Estado { get; set; }
        public int Proveedor { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("Estado")] public Estados? _Estado { get; set; }

        public bool Validar()
        {
            if (Fecha_llegada == null ||
                Fecha_vencimiento == null ||
                Cantidad <= 0 ||
                Precio_unitario <= (decimal)0.009 ||
                string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }

    }
}
