using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_utilidades;
using lib_comunicaciones.Interfaces;
using lib_comunicaciones.Implementaciones;
using mst_comunicaciones.Nucleo;

namespace mst_comunicaciones.UnitTest
{
    [TestClass]
    public class CategoriasComUnitTest
    {
        private ICategoriasComunicacion? iComunicacion = null;
        private Categorias? entidad = null;
        private List<Categorias>? lista = null;
        private static string token = null;
        private TokenHelper TokenHelper;



        public CategoriasComUnitTest()
        {
            iComunicacion = new CategoriasComunicacion();
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
            entidad = EntidadesHelper.ObtenerCategorias();
            dicc!["Entidad"] = entidad;
            dicc!["Token"] = token;


            var datos = await iComunicacion!.Guardar(dicc);

            var enti = entidad = JsonConversor.ConvertirAObjeto<Categorias>(
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