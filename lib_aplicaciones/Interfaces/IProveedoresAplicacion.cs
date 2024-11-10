using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string string_conexion);
        List<Proveedores> Buscar(Proveedores entidad, string tipo);
        List<Proveedores> Listar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}

