using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICategoriasPresentacion
    {
        Task<List<Categorias>> Listar();
        Task<List<Categorias>> Buscar(Categorias entidad, string tipo);
        Task<Categorias> Guardar(Categorias entidad);
        Task<Categorias> Modificar(Categorias entidad);
        Task<Categorias> Borrar(Categorias entidad);
    }
}
