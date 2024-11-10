using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriasAplicacion
    {
        void Configurar(string string_conexion);
        List<Categorias> Buscar(Categorias entidad, string tipo);
        List<Categorias> Listar();
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
    }
}

