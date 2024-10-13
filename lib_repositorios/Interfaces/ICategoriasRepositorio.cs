using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface ICategoriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Categorias> Listar();
        Categorias Guardar(Categorias entidad);
        List<Categorias> Buscar(Expression<Func<Categorias, bool>> condiciones);
        Categorias Modificar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
    }
}
