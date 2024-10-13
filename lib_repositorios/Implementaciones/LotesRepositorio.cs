using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class LotesRepositorio : ILotesRepositorio
    {
        private Conexion? conexion = null;

        public LotesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Lotes> Listar()
        {
            return conexion!.Listar<Lotes>();
        }

        public List<Lotes> Buscar(Expression<Func<Lotes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Lotes Guardar(Lotes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Lotes Buscar(Lotes entidad)
        {
            conexion!.Buscar<Lotes>(x => x.Id != entidad!.Id);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Lotes Modificar(Lotes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public Lotes Borrar(Lotes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }

        public bool Existe(Expression<Func<Lotes, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}