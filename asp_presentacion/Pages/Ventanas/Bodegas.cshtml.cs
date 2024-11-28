using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using System.Collections.Generic;


namespace asp_presentacion.Pages.Ventanas
{
    public class BodegasModel : PageModel
    {
        private IBodegasPresentacion? iPresentacion = null;
        private ISucursalesPresentacion? iSucursalesPresentacion = null;
        private IAuditoriasPresentacion? iAuditoria = null;

        public BodegasModel(IBodegasPresentacion iPresentacion, ISucursalesPresentacion iSucursalesPresentacion, IAuditoriasPresentacion iAuditoria)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iSucursalesPresentacion = iSucursalesPresentacion;
                Filtro = new Bodegas();
                this.iAuditoria = iAuditoria;
                Auditoria = new Auditorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Bodegas? Actual { get; set; }
        [BindProperty] public Bodegas? Filtro { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public List<Bodegas>? Lista { get; set; }
        [BindProperty] public List<Sucursales>? Sucursales { get; set; }


        public ActionResult OnGet()
        {
            if (HttpContext.Session.Keys.Contains("Usuario"))
            {
                OnPostBtRefrescar();
                return Page();
            }
            else
            {
                return Redirect("../");
            }
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Filtro!.Nombre = Filtro!.Nombre ?? "";

                
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!,"NOMBRE", HttpContext.Session.GetString("Token")!);
                task.Wait();
                Lista = task.Result;
                CargarCombox();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                CargarCombox();
                Actual = new Bodegas()
                {
                
                };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                CargarCombox();
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Task<Bodegas>? task = null;
                Task<Auditorias>? Auditoria = null;
                Auditorias audi = new Auditorias();
                if (Actual!.Id == 0)
                {
                    task = iPresentacion!.Guardar(Actual!, HttpContext.Session.GetString("Token")!);
                    audi.Usuario = (int)HttpContext.Session.GetInt32("ID")!;
                    audi.Fecha = DateTime.Now;
                    audi.Accion = 1;
                }
                else
                {
                    task = iPresentacion!.Modificar(Actual!, HttpContext.Session.GetString("Token")!);
                    audi.Usuario = (int)HttpContext.Session.GetInt32("ID")!;
                    audi.Fecha = DateTime.Now;
                    audi.Accion = 2;

                }
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                Auditoria = iAuditoria!.Guardar(audi, HttpContext.Session.GetString("Token")!, Actual!);
                Auditoria.Wait();
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                Task<Auditorias>? Auditoria = null;
                Auditorias audi = new Auditorias();
                audi.Usuario = (int)HttpContext.Session.GetInt32("ID")!;
                audi.Fecha = DateTime.Now;
                audi.Accion = 3;
                var task = iPresentacion!.Borrar(Actual!, HttpContext.Session.GetString("Token")!);
                Actual = task.Result;
                Auditoria = iAuditoria!.Guardar(audi, HttpContext.Session.GetString("Token")!, Actual!);
                Auditoria.Wait();
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                CargarCombox();
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarCombox()
        {
            try
            {
                if (!(Sucursales == null || Sucursales!.Count <= 0))
                    return;

                var task = this.iSucursalesPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Sucursales = JsonConversor.ConvertirAObjeto<List<Sucursales>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipo(int id)
        {
            try
            {
                CargarCombox();
                return Sucursales!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public virtual IActionResult OnPostBtDescargarExcel()
        {
            try
            {
                // Establecer el contexto de licencia
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // o LicenseContext.Commercial según sea el caso
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                // Obtener la lista de bodegas
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE", HttpContext.Session.GetString("Token")!);
                task.Wait();
                Lista = task.Result;

                // Verificar que la lista de bodegas no esté vacía
                if (Lista! == null || !Lista.Any())
                {
                    return NotFound("No hay bodegas disponibles.");
                }

                // Crear un paquete Excel
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Bodegas");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Nombre";
                    worksheet.Cells[1, 2].Value = "Cantidad de Estantes";
                    worksheet.Cells[1, 3].Value = "Valor de Bodega";
                    worksheet.Cells[1, 4].Value = "Sucursal";

                    int row = 2;

                    foreach (var bodega in Lista!)
                    {
                        // Asignar valores a las celdas
                        worksheet.Cells[row, 1].Value = bodega.Nombre; // Nombre de la bodega
                        worksheet.Cells[row, 2].Value = bodega.Cantidad_estante; // Cantidad de estantes
                        worksheet.Cells[row, 3].Value = bodega.Valor_bodega; // Valor de la bodega
                        worksheet.Cells[row, 4].Value = bodega._Sucursal?.Nombre; // Nombre de la sucursal

                        row++; // Incrementar el contador de filas
                    }

                    // Configurar la respuesta para descargar el archivo
                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    var fileName = "Bodegas.xlsx";
                    stream.Position = 0;

                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return RedirectToPage(); // Redirigir en caso de error
            }
        }
    }
}