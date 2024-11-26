using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Bodegas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad_estante { get; set; }
        public decimal Valor_bodega { get; set; }
        public int Sucursal { get; set; }

        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
        [NotMapped] public virtual ICollection<Estantes>? Estantes { get; set; }


        //public decimal CalcularValorBodega()
        //{
        //    return Estantes.Sum(e => e.Valor);
        //}

        public bool Validar()
        {
            if (Cantidad_estante <= 0 ||
                Valor_bodega <= (decimal)0.009 ||
                string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}