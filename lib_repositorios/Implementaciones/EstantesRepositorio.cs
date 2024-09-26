﻿using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstantesRepositorio : IEstantesRepositorio
    {
        private Conexion? conexion;

        public EstantesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estantes> Listar()
        {
            return conexion!.Listar<Estantes>();
        }

        public List<Estantes> Buscar(Expression<Func<Estantes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estantes Guardar(Estantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Estantes Modificar(Estantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public Estantes Borrar(Estantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separadar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Estantes, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}