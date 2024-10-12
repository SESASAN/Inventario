using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private Conexion? conexion;

        public CategoriasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Categorias> Listar()
        {
            return conexion!.Listar<Categorias>();
        }

        public List<Categorias> Buscar(Expression<Func<Categorias, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Categorias Guardar(Categorias entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Categorias Modificar(Categorias entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Categorias Borrar(Categorias entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Categorias, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}