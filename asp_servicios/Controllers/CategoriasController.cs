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
    public class CategoriasController : ControllerBase 
    {
        private ICategoriasAplicacion? IAplicacion = null;
        public CategoriasController()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=Inventario_db.mssql.somee.com;packet size=4096;database=Inventario_db;user id=TequeñosItm_SQLLogin_1;pwd=e5cqe5m6zo;data source=Inventario_db.mssql.somee.com;persist security info=False; initial catalog=Inventario_db;TrustServerCertificate=True;";
            IAplicacion = new CategoriasAplicacion(
            new CategoriasRepositorio(conexion));
        }
        [HttpGet]
        public IEnumerable<Categorias> Get()
        {
            var lista = IAplicacion!.Listar();
            return lista.ToArray();
        }
    }
}