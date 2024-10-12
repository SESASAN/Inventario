using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Bodegas
    {
        [Key] public int Id { get; set; }
        public int Cantidad_estante { get; set; }
        public decimal Valor_bodega { get; set; }
        public int Sucursal { get; set; }

        [NotMapped] public Sucursales? _Sucursal { get; set; }

        public void ObtenerValorBodega() { }
        public void CalcularProcutoMasVendido() { }
    }
}
