using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IProductosRepositorio
    {
        void Configurar(string string_conexion);
        List<Productos> Listar();
        List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones);
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
        bool Existe(Expression<Func<Productos, bool>> condiciones);
    }
}