using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IBodegasAplicacion
    {
        void Configurar(string string_conexion);
        List<Bodegas> Buscar(Bodegas entidad, string tipo);
        List<Bodegas> Listar();
        Bodegas Guardar(Bodegas entidad);
        Bodegas Modificar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
    }
}