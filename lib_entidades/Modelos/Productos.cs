using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio_venta { get; set; }
        public decimal Iva { get; set; }
        public int Categoria { get; set; }
        public int Estante { get; set; }

        [NotMapped] public Categorias? _Categoria { get; set; }
        [NotMapped] public Estantes? _Estante { get; set; }

        public void FiltrarPorCategoria() { }
        public void CalcularEstado() { }

    }
}
