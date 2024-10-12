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
    public class LotesController : ControllerBase
    {
        private ILotesAplicacion? IAplicacion = null;
        public LotesController()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=Inventario_db.mssql.somee.com;packet size=4096;database=Inventario_db;user id=Teque�osItm_SQLLogin_1;pwd=e5cqe5m6zo;data source=Inventario_db.mssql.somee.com;persist security info=False; initial catalog=Inventario_db;TrustServerCertificate=True;";
            IAplicacion = new LotesAplicacion(
            new LotesRepositorio(conexion));
        }
        [HttpGet]
        public IEnumerable<Lotes> Get()
        {
            var lista = IAplicacion!.Listar();
            return lista.ToArray();
        }
    }
}