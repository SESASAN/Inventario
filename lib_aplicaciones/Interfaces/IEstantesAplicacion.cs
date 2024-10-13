using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstantesAplicacion
    {
        void Configurar(string string_conexion);
        List<Estantes> Listar();
        Estantes Guardar(Estantes entidad);
        Estantes Modificar(Estantes entidad);
        Estantes Borrar(Estantes entidad);
    }
}

