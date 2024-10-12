using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstantesAplicacion
    {
        List<Estantes> Listar();
        List<Estantes> Buscar(Estantes entidad, string tipo);
        Estantes Guardar(Estantes entidad);
        Estantes Modificar(Estantes entidad);
        Estantes Borrar(Estantes entidad);
    }
}

