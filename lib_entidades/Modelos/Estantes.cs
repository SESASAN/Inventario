using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Estantes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad_producto { get; set; }
        public int Bodega { get; set; }
        public int Categoria { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("Bodega")] public Bodegas? _Bodega { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
        [NotMapped] public virtual ICollection<Productos>? Productos { get; set; }
        [NotMapped] public virtual ICollection<Lotes>? Lotes { get; set; }

        public bool Validar()
        {
            if (Cantidad_producto <= 0 ||
                Valor <= 0)
                return false;
            return true;
        }
    }
}
