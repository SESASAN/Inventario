using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ILotesAplicacion
    {
        void Configurar(string string_conexion);
        List<Lotes> Buscar(Lotes entidad, string tipo);
        List<Lotes> Listar();
        Lotes Guardar(Lotes entidad);
        Lotes Modificar(Lotes entidad);
        Lotes Borrar(Lotes entidad);
    }
}

