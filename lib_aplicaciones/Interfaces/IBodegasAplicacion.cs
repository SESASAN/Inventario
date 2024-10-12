using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IBodegasAplicacion
    {
        List<Bodegas> Listar();
        List<Bodegas> Buscar(Bodegas entidad, string tipo);
        Bodegas Guardar(Bodegas entidad);
        Bodegas Modificar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
    }
}

