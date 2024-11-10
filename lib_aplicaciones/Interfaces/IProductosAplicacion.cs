using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string string_conexion);
        List<Productos> Buscar(Productos entidad, string tipo);
        List<Productos> Listar();
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}

