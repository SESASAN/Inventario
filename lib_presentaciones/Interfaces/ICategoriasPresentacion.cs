using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICategoriasPresentacion
    {
        Task<List<Categorias>> Listar(string token);
        Task<List<Categorias>> Buscar(Categorias entidad, string tipo, string token);
        Task<Categorias> Guardar(Categorias entidad, string token);
        Task<Categorias> Modificar(Categorias entidad, string token);
        Task<Categorias> Borrar(Categorias entidad, string token);
    }
}
