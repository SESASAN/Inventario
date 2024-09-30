using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ILotesRepositorio
    {
        void Configurar(string string_conexion);
        List<Lotes> Listar();
        List<Lotes> Buscar(Expression<Func<Lotes, bool>> condiciones);
        Lotes Guardar(Lotes entidad);
        Lotes Modificar(Lotes entidad);
        Lotes Borrar(Lotes entidad);
        bool Existe(Expression<Func<Lotes, bool>> condiciones);
    }
}