using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IBodegasRepositorio
    {
        void Configurar(string string_conexion);
        List<Bodegas> Listar();
        Bodegas Guardar(Bodegas entidad);
        List<Bodegas> Buscar(Expression<Func<Bodegas, bool>> condiciones);
        Bodegas Modificar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
    }
}
