using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IRolesAplicacion
    {
        void Configurar(string string_conexion);
        List<Roles> Listar();
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}

