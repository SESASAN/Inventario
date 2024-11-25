using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Roles
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Permiso { get; set; }

        [NotMapped] public virtual ICollection<Usuarios>? Usuarios { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}
