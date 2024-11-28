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
    public class RolesModel : PageModel
    {
        private IRolesPresentacion? iPresentacion = null;
        private IAuditoriasPresentacion? iAuditoria = null;

        public RolesModel(IRolesPresentacion iPresentacion, IAuditoriasPresentacion iAuditoria)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Roles();
                this.iAuditoria = iAuditoria;
                Auditoria = new Auditorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Roles? Actual { get; set; }
        [BindProperty] public Roles? Filtro { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public List<Roles>? Lista { get; set; }

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
                Actual = new Roles()
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
                Task<Roles>? task = null;
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
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual IActionResult OnPostBtDescargarExcel()
        {
            try
            {
                // Establecer el contexto de licencia
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // o LicenseContext.Commercial según sea el caso
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                // Obtener la lista de Roles
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE", HttpContext.Session.GetString("Token")!);
                task.Wait();
                Lista = task.Result;

                // Verificar que la lista de Roles no esté vacía
                if (Lista! == null || !Lista.Any())
                {
                    return NotFound("No hay Roles disponibles.");
                }

                // Crear un paquete Excel
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Roles");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Nombre";
                    worksheet.Cells[1, 2].Value = "Permiso";

                    int row = 2;

                    foreach (var Rol in Lista!)
                    {
                        // Asignar valores a las celdas
                        worksheet.Cells[row, 1].Value = Rol.Nombre;
                        worksheet.Cells[row, 2].Value = Rol.Permiso;

                        row++; // Incrementar el contador de filas
                    }

                    // Configurar la respuesta para descargar el archivo
                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    var fileName = "Roles.xlsx";
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