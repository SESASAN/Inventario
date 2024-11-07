using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IProveedoresPresentacion
    {
        Task<List<Proveedores>> Listar();
        Task<List<Proveedores>> Buscar(Proveedores entidad, string tipo);
        Task<Proveedores> Guardar(Proveedores entidad);
        Task<Proveedores> Modificar(Proveedores entidad);
        Task<Proveedores> Borrar(Proveedores entidad);
    }
}