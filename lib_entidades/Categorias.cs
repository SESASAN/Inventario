using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Categorias
    {
        public enum Grupos { PRODUCTO = 0, SECCION = 1 }

        [Key] public int Id { get; set; }

        public string? Nombre { get; set; }

        public int Grupo { get; set; }
    }
}
