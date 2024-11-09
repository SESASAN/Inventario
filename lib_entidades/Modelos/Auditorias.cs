using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Accion { get; set; }
        public string? Entidad { get; set; }

        [NotMapped] public Usuarios? _Usuario { get; set; }
        [NotMapped] public Acciones? _Acciones { get; set; }

        public bool Validar()
        {
            if (Usuario == 0 || 
                Accion == 0 ||
                Fecha == null
                )
                return false;
            return true;
        }
    }
}
