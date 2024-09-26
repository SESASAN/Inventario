using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ICategoriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Categorias> Listar();
        List<Categorias> Buscar(Expression<Func<Categorias, bool>> condiciones);
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
        bool Existe(Expression<Func<Categorias, bool>> condiciones);
    }
}