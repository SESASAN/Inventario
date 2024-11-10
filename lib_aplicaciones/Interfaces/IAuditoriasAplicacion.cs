using lib_entidades.Modelos;
namespace lib_aplicaciones.Interfaces
{
    public interface IAuditoriasAplicacion
    {
        void Configurar(string string_conexion);
        List<Auditorias> Listar();
        Auditorias Guardar(Auditorias entidad);
        List<Auditorias> Buscar(Auditorias entidad, string tipo);
    }
}

