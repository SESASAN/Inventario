using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IEstadosRepositorio
    {
        void Configurar(string string_conexion);
        List<Estados> Listar();
        List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones);
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
        bool Existe(Expression<Func<Estados, bool>> condiciones);
    }
}