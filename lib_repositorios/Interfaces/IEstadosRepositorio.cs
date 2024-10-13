using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IEstadosRepositorio
    {
        void Configurar(string string_conexion);
        List<Estados> Listar();
        Estados Guardar(Estados entidad);
        List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}
