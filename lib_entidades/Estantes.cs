using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Estantes
    {
        [Key] public int Id { get; set; }
        public Productos? Producto { get; set; }
        public int Cantidad_producto { get; set; }
        public Bodegas? Bodega { get; set; }
        public Categorias? Categoria { get; set; }
        

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Bodegas? _Bodega { get; set; }
        [NotMapped] public Categorias? _Categoria { get; set; }
    }
}
