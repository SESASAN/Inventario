using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IAccionesAplicacion
    {
        void Configurar(string string_conexion);
        List<Acciones> Listar();
        Acciones Guardar(Acciones entidad);
        Acciones Modificar(Acciones entidad);
        Acciones Borrar(Acciones entidad);
    }
}

