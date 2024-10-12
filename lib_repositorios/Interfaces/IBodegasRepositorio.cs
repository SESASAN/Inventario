using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IBodegasRepositorio
    {
        void Configurar(string string_conexion);
        List<Bodegas> Listar();
        List<Bodegas> Buscar(Expression<Func<Bodegas, bool>> condiciones);
        Bodegas Guardar(Bodegas entidad);
        Bodegas Modificar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
        bool Existe(Expression<Func<Bodegas, bool>> condiciones);
    }
}