﻿using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas_unitarias.Nucleo;

namespace mst_pruebas_unitarias.Repositorios
{
    [TestClass]
    public class RolesUnitTest
    {
        private IRolesRepositorio? iRepositorio = null;
        private Conexion? conexion = null;
        private Roles? entidad = null;
        private List<Roles>? lista = null;

        public RolesUnitTest()
        {
            conexion = new Conexion();
            conexion!.StringConnection = "server=LAPTOP-O5Q01CH6\\SQLEXPRESS;database=Inventario_db;Integrated Security=True;TrustServerCertificate=true;";
            //conexion!.StringConnection = "server=Inventario_db.mssql.somee.com;packet size=4096;database=Inventario_db;user id=TequeñosItm_SQLLogin_1;pwd=e5cqe5m6zo;data source=Inventario_db.mssql.somee.com;persist security info=False; initial catalog=Inventario_db;TrustServerCertificate=True;";
            iRepositorio = new RolesRepositorio(conexion);
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
            entidad = EntidadesHelper.ObtenerRoles();
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