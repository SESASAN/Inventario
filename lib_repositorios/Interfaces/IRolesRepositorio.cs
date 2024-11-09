using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IRolesRepositorio
    {
        void Configurar(string string_conexion);
        List<Roles> Listar();
        Roles Guardar(Roles entidad);
        List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones);
        Roles Modificar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}
