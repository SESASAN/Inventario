using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Categorias
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }

        [NotMapped] public virtual ICollection<Estantes>? Estantes { get; set; }
        [NotMapped] public virtual ICollection<Productos>? Productos { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }

    }
}
