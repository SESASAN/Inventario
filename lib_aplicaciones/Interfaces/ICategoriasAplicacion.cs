using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriasAplicacion
    {
        List<Categorias> Listar();
        List<Categorias> Buscar(Categorias entidad, string tipo);
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
    }
}

