﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombre_Usuario { get; set; }
        public string? Clave { get; set; }
        public int Rol { get; set; }

        [NotMapped] public Roles? _Rol { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || 
                string.IsNullOrEmpty(Clave)
                )
                return false;
            return true;
        }
    }
}
