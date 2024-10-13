using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IEstantesRepositorio
    {
        void Configurar(string string_conexion);
        List<Estantes> Listar();
        Estantes Guardar(Estantes entidad);
        List<Estantes> Buscar(Expression<Func<Estantes, bool>> condiciones);
        Estantes Modificar(Estantes entidad);
        Estantes Borrar(Estantes entidad);
    }
}
