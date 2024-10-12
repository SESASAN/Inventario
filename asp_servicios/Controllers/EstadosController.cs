using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using Microsoft.AspNetCore.Mvc;
namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadosController : ControllerBase
    {
        private IEstadosAplicacion? IAplicacion = null;
        public EstadosController()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=Inventario_db.mssql.somee.com;packet size=4096;database=Inventario_db;user id=TequeñosItm_SQLLogin_1;pwd=e5cqe5m6zo;data source=Inventario_db.mssql.somee.com;persist security info=False; initial catalog=Inventario_db;TrustServerCertificate=True;";
            IAplicacion = new EstadosAplicacion(
            new EstadosRepositorio(conexion));
        }
        [HttpGet]
        public IEnumerable<Estados> Get()
        {
            var lista = IAplicacion!.Listar();
            return lista.ToArray();
        }
    }
}