using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IProductosRepositorio
    {
        void Configurar(string string_conexion);
        List<Productos> Listar();
        Productos Guardar(Productos entidad);
        List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
