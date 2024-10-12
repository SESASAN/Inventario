using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ILotesAplicacion
    {
        List<Lotes> Listar();
        List<Lotes> Buscar(Lotes entidad, string tipo);
        Lotes Guardar(Lotes entidad);
        Lotes Modificar(Lotes entidad);
        Lotes Borrar(Lotes entidad);
    }
}

