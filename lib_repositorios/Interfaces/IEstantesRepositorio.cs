using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IEstantesRepositorio
    {
        void Configurar(string string_conexion);
        List<Estantes> Listar();
        List<Estantes> Buscar(Expression<Func<Estantes, bool>> condiciones);
        Estantes Guardar(Estantes entidad);
        Estantes Modificar(Estantes entidad);
        Estantes Borrar(Estantes entidad);
        bool Existe(Expression<Func<Estantes, bool>> condiciones);
    }
}