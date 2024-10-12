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
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresAplicacion? IAplicacion = null;
        public ProveedoresController()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=Inventario_db.mssql.somee.com;packet size=4096;database=Inventario_db;user id=TequeñosItm_SQLLogin_1;pwd=e5cqe5m6zo;data source=Inventario_db.mssql.somee.com;persist security info=False; initial catalog=Inventario_db;TrustServerCertificate=True;";
            IAplicacion = new ProveedoresAplicacion(
            new ProveedoresRepositorio(conexion));
        }
        [HttpGet]
        public IEnumerable<Proveedores> Get()
        {
            var lista = IAplicacion!.Listar();
            return lista.ToArray();
        }
    }
}