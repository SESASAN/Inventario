using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using lib_entidades.Modelos;
using System.Linq.Expressions;
namespace lib_aplicaciones.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IAuditoriasRepositorio? iRepositorio = null;
        public AuditoriasAplicacion(IAuditoriasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }
        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbNoSeGuardo");
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }
        public List<Auditorias> Listar()
        {
            return iRepositorio!.Listar();
        }
        public List<Auditorias> Buscar(Auditorias entidad, string tipo)
        {
            Expression<Func<Auditorias, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

    }
}

