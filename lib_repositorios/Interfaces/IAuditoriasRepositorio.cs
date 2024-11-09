using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IAuditoriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Auditorias> Listar();
        Auditorias Guardar(Auditorias entidad);
        List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones);

    }
}
