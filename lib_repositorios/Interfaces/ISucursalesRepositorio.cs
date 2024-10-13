using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface ISucursalesRepositorio
    {
        void Configurar(string string_conexion);
        List<Sucursales> Listar();
        Sucursales Guardar(Sucursales entidad);
        List<Sucursales> Buscar(Expression<Func<Sucursales, bool>> condiciones);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Borrar(Sucursales entidad);
    }
}
