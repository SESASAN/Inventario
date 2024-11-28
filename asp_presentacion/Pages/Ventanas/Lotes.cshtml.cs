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
    public class LotesModel : PageModel
    {
        private ILotesPresentacion? iPresentacion = null;
        private IProductosPresentacion? iProductosPresentacion = null;
        private IEstadosPresentacion? iEstadosPresentacion = null;
        private IProveedoresPresentacion? iProveedoresPresentacion = null;
        private IAuditoriasPresentacion? iAuditoria = null;

        public LotesModel(ILotesPresentacion iPresentacion, IProductosPresentacion iProductosPresentacion, IEstadosPresentacion iEstadosPresentacion, IProveedoresPresentacion iProveedoresPresentacion, IAuditoriasPresentacion iAuditoria)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iProductosPresentacion=iProductosPresentacion;
                this.iEstadosPresentacion= iEstadosPresentacion;
                this.iProveedoresPresentacion= iProveedoresPresentacion;
                Filtro = new Lotes();
                this.iAuditoria = iAuditoria;
                Auditoria = new Auditorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Lotes? Actual { get; set; }
        [BindProperty] public Lotes? Filtro { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public List<Lotes>? Lista { get; set; }
        [BindProperty] public List<Productos>? Productos { get; set; }
        [BindProperty] public List<Estados>? Estados { get; set; }
        [BindProperty] public List<Proveedores>? Proveedores { get; set; }

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
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE", HttpContext.Session.GetString("Token")!);
                task.Wait();
                CargarComboxPrd();
                CargarComboxEst();
                CargarComboxPrv();
                Lista = task.Result;
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
                CargarComboxPrd();
                CargarComboxEst();
                CargarComboxPrv();
                Actual = new Lotes()
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
                CargarComboxPrd();
                CargarComboxEst();
                CargarComboxPrv();
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
                Task<Lotes>? task = null;
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
                CargarComboxPrd();
                CargarComboxEst();
                CargarComboxPrv();
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarComboxPrd()
        {
            try
            {
                if (!(Productos == null || Productos!.Count <= 0))
                    return;

                var task = this.iProductosPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Productos = JsonConversor.ConvertirAObjeto<List<Productos>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipoPrd(int id)
        {
            try
            {
                CargarComboxPrd();
                return Productos!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public void CargarComboxEst()
        {
            try
            {
                if (!(Estados == null || Estados!.Count <= 0))
                    return;

                var task = this.iEstadosPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Estados = JsonConversor.ConvertirAObjeto<List<Estados>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipoEst(int id)
        {
            try
            {
                CargarComboxEst();
                return Estados!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public void CargarComboxPrv()
        {
            try
            {
                if (!(Proveedores == null || Proveedores!.Count <= 0))
                    return;

                var task = this.iProveedoresPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Proveedores = JsonConversor.ConvertirAObjeto<List<Proveedores>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipoPrv(int id)
        {
            try
            {
                CargarComboxPrv();
                return Proveedores!.FirstOrDefault(x => x.Id == id)!.Nombre!;
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
                // Obtener la lista de lotes
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE", HttpContext.Session.GetString("Token")!);
                task.Wait();
                Lista = task.Result;

                // Verificar que la lista de lotes no esté vacía
                if (Lista! == null || !Lista.Any())
                {
                    return NotFound("No hay lotes disponibles.");
                }

                // Crear un paquete Excel
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Lotes");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Nombre";
                    worksheet.Cells[1, 2].Value = "Producto";
                    worksheet.Cells[1, 3].Value = "Fecha de llegada";
                    worksheet.Cells[1, 4].Value = "Fecha de vencimiento";
                    worksheet.Cells[1, 5].Value = "Cantidad";
                    worksheet.Cells[1, 6].Value = "Precio Unitario";
                    worksheet.Cells[1, 7].Value = "Estado";
                    worksheet.Cells[1, 8].Value = "Proveedor";

                    int row = 2;

                    foreach (var lote in Lista!)
                    {
                        // Asignar valores a las celdas
                        worksheet.Cells[row, 1].Value = lote.Nombre;
                        worksheet.Cells[row, 2].Value = lote._Producto?.Nombre;
                        worksheet.Cells[row, 3].Value = lote.Fecha_llegada;
                        worksheet.Cells[row, 4].Value = lote.Fecha_vencimiento;
                        worksheet.Cells[row, 5].Value = lote.Cantidad;
                        worksheet.Cells[row, 6].Value = lote.Precio_unitario;
                        worksheet.Cells[row, 7].Value = lote._Estado?.Nombre;
                        worksheet.Cells[row, 8].Value = lote._Proveedor?.Nombre;

                        row++; // Incrementar el contador de filas
                    }

                    // Configurar la respuesta para descargar el archivo
                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    var fileName = "Lotes.xlsx";
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