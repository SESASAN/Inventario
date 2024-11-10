using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ISucursalesAplicacion
    {
        void Configurar(string string_conexion);
        List<Sucursales> Buscar(Sucursales entidad, string tipo);
        List<Sucursales> Listar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Borrar(Sucursales entidad);
    }
}

