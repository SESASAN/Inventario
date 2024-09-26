using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IProveedoresRepositorio
    {
        void Configurar(string string_conexion);
        List<Proveedores> Listar();
        List<Proveedores> Buscar(Expression<Func<Proveedores, bool>> condiciones);
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
        bool Existe(Expression<Func<Proveedores, bool>> condiciones);
    }
}