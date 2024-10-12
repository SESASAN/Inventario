using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ISucursalesAplicacion
    {
        List<Sucursales> Listar();
        List<Sucursales> Buscar(Sucursales entidad, string tipo);
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Borrar(Sucursales entidad);
    }
}

