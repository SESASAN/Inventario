using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        List<Estados> Listar();
        List<Estados> Buscar(Estados entidad, string tipo);
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}

