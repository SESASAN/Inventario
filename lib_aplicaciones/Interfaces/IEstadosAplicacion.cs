using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        void Configurar(string string_conexion);
        List<Estados> Buscar(Estados entidad, string tipo);
        List<Estados> Listar();
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}

