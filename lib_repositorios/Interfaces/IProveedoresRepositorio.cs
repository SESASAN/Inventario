using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_repositorios.Interfaces
{
    public interface IProveedoresRepositorio
    {
        void Configurar(string string_conexion);
        List<Proveedores> Listar();
        Proveedores Guardar(Proveedores entidad);
        List<Proveedores> Buscar(Expression<Func<Proveedores, bool>> condiciones);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
