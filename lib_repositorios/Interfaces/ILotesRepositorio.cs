using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface ILotesRepositorio
    {
        void Configurar(string string_conexion);
        List<Lotes> Listar();
        Lotes Guardar(Lotes entidad);
        List<Lotes> Buscar(Expression<Func<Lotes, bool>> condiciones);
        Lotes Modificar(Lotes entidad);
        Lotes Borrar(Lotes entidad);
    }
}
