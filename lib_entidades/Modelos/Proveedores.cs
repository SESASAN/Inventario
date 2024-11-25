using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Proveedores
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        [NotMapped] public virtual ICollection<Lotes>? Lotes { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Direccion) ||
                string.IsNullOrEmpty(Telefono))
                return false;
            return true;
        }
    }
}
