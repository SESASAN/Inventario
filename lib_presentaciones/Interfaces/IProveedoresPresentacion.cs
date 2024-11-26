using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IProveedoresPresentacion
    {
        Task<List<Proveedores>> Listar(string token);
        Task<List<Proveedores>> Buscar(Proveedores entidad, string tipo, string token);
        Task<Proveedores> Guardar(Proveedores entidad, string token);
        Task<Proveedores> Modificar(Proveedores entidad, string token);
        Task<Proveedores> Borrar(Proveedores entidad, string token);
    }
}