using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Bodegas
    {
        [Key] public int Id { get; set; }
        public int Cantidad_estante { get; set; }
        public decimal Valor_bodega { get; set; }
        public int Sucursal { get; set; }

        [NotMapped] public Sucursales? _Sucursal { get; set; }

        public void CalcularValorBodega() { }
        public void CalcularProcutoMayorCantidad() { }
        public bool Validar()
        {
            if (Cantidad_estante <= 0 ||
                Valor_bodega <= 0)
                return false;
            return true;
        }
    }
}