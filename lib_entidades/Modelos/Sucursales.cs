using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Sucursales
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        [NotMapped] public virtual ICollection<Bodegas>? Bodegas { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Direccion))
                return false;
            return true;
        }
    }
}
