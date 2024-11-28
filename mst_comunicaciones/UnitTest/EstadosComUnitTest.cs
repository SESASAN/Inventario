using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_utilidades;
using lib_comunicaciones.Interfaces;
using lib_comunicaciones.Implementaciones;
using mst_comunicaciones.Nucleo;

namespace mst_comunicaciones.UnitTest
{
    [TestClass]
    public class EstadosComUnitTest
    {
        private IEstadosComunicacion? iComunicacion = null;
        private Estados? entidad = null;
        private List<Estados>? lista = null;
        private static string token = null;
        private TokenHelper TokenHelper;



        public EstadosComUnitTest()
        {
            iComunicacion = new EstadosComunicacion();
            TokenHelper = new TokenHelper();
            var task = TokenHelper.Autenticar();
            task.Wait();
            token = task.Result;

        }

        [TestMethod]
        public async Task TestMethod1()
        {
            await Listar();
            await Guardar();
            await Modificar();
            await Borrar();
        }

        private async Task Guardar()
        {
            var dicc = new Dictionary<string, object>();
            entidad = EntidadesHelper.ObtenerEstados();
            dicc!["Entidad"] = entidad;
            dicc!["Token"] = token;


            var datos = await iComunicacion!.Guardar(dicc);

            var enti = entidad = JsonConversor.ConvertirAObjeto<Estados>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
            entidad.Id = enti.Id;
            Assert.IsTrue(!datos.ContainsKey("Error"));

        }
        private async Task Listar()
        {
            var dicc = new Dictionary<string, object>();
            dicc!["Token"] = token;
            var datos = await iComunicacion!.Listar(dicc);

            Assert.IsTrue(!datos.ContainsKey("Error"));
        }

        private async Task Modificar()
        {
            var dicc = new Dictionary<string, object>();
            entidad!.Nombre = entidad.Nombre + " " + DateTime.Now.ToString();
            dicc!["Entidad"] = entidad;
            dicc!["Token"] = token;


            var datos = await iComunicacion!.Modificar(dicc);

            Assert.IsTrue(!datos.ContainsKey("Error"));

        }

        private async Task Borrar()
        {
            var dicc = new Dictionary<string, object>();
            dicc!["Entidad"] = entidad!;
            dicc!["Token"] = token;


            var datos = await iComunicacion!.Borrar(dicc);

            Assert.IsTrue(!datos.ContainsKey("Error"));

        }
    }
}