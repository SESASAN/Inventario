using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Bodegas
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor_bodega { get; set; }
        public int Sucursal { get; set; }

        [NotMapped] public Sucursales? _Sucursal { get; set; }
    }
}
