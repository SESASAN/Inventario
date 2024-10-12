using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Estantes
    {
        [Key] public int Id { get; set; }
        public int Cantidad_producto { get; set; }
        public int Bodega { get; set; }
        public int Categoria { get; set; }
        public decimal Valor { get; set; }

        [NotMapped] public Bodegas? _Bodega { get; set; }
        [NotMapped] public Categorias? _Categoria { get; set; }
    }
}
