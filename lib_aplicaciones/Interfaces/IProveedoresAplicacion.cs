using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IProveedoresAplicacion
    {
        List<Proveedores> Listar();
        List<Proveedores> Buscar(Proveedores entidad, string tipo);
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}

