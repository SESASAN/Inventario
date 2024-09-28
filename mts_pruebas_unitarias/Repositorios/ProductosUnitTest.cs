using lib_entidades;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas_unitarias.Nucleo;
using mst_unittests.Nucleo;

namespace mts_pruebas_unitarias.Repositorios
{
    [TestClass]
    public class ProductosUnitTest
    {
        private IProductosRepositorio? iRepositorio = null;
        private Conexion? conexion = null;
        private Productos? entidad = null;
        private List<Productos>? lista = null;

        public ProductosUnitTest()
        {
            conexion = new Conexion();
            conexion!.StringConnection = ConfiguracionHelper.ObtenerValor("ConectionString");
            iRepositorio = new ProductosRepositorio(conexion);
        }

        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Listar()
        {
            lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar()
        {
            lista = iRepositorio!.Buscar(x => x.Id != entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        public void Guardar()
        {
            entidad = EntidadesHelper.ObtenerProductos();
            entidad = iRepositorio!.Guardar(entidad!);
            Assert.IsTrue(entidad.Id != 0);
        }

        public void Modificar()
        {
            entidad!.Nombre = entidad.Nombre + " " + DateTime.Now.ToString();
            entidad = iRepositorio!.Modificar(entidad!);

            lista = iRepositorio!.Buscar(x => x.Id == entidad.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        public void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}