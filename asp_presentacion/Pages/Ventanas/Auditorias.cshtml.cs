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
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasPresentacion? iPresentacion = null;

        public AuditoriasModel(IAuditoriasPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Auditorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Auditorias? Actual { get; set; }
        [BindProperty] public Auditorias? Filtro { get; set; }
        [BindProperty] public List<Auditorias>? Lista { get; set; }

        public ActionResult OnGet() 
        {
            if (HttpContext.Session.Keys.Contains("Usuario") && HttpContext.Session.GetString("Permisos")!.ToUpper().Equals("TRUE"))
            {
                OnPostBtRefrescar();
                return Page();
            }
            if (HttpContext.Session.GetString("Permisos")!.ToUpper().Equals("FALSE"))
            {
                return Redirect("../Home");
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
                Accion = Enumerables.Ventanas.Listas;
                var task = iPresentacion!.Listar( HttpContext.Session.GetString("Token")!);
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
                Actual = new Auditorias()
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
        // CORREGIR EL BOTON QUE NO SE PUEDA GUARDAR AUDITORIAS DESDE LA PAGINA
        //public virtual void OnPostBtGuardar()
        //{
        //    try
        //    {
        //        Accion = Enumerables.Ventanas.Editar;
        //        Task<Auditorias>? task = null;
        //        if (Actual!.Id == 0)
        //            task = iPresentacion!.Guardar(Actual!, HttpContext.Session.GetString("Token")!);
        //        task.Wait();
        //        Actual = task.Result;
        //        Accion = Enumerables.Ventanas.Listas;
        //        OnPostBtRefrescar();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

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

        //public virtual void OnPostBtBorrar()
        //{
        //    try
        //    {
        //        var task = iPresentacion!.Borrar(Actual!);
        //        Actual = task.Result;
        //        OnPostBtRefrescar();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

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
                // Obtener la lista de auditorias
                var task = this.iPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Lista = task.Result;

                // Verificar que la lista de auditorias no esté vacía
                if (Lista! == null || !Lista.Any())
                {
                    return NotFound("No hay auditorias disponibles.");
                }

                // Crear un paquete Excel
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Auditorias");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Usuario";
                    worksheet.Cells[1, 2].Value = "Fecha";
                    worksheet.Cells[1, 3].Value = "Acción";
                    worksheet.Cells[1, 4].Value = "Entidad";

                    int row = 2;

                    foreach (var auditoria in Lista!)
                    {
                        // Asignar valores a las celdas
                        worksheet.Cells[row, 1].Value = auditoria.Usuario; // Nombre de la auditoria
                        worksheet.Cells[row, 2].Value = auditoria.Fecha; // Cantidad de estantes
                        worksheet.Cells[row, 3].Value = auditoria.Accion; // Valor de la auditoria
                        worksheet.Cells[row, 4].Value = auditoria.Entidad; // Nombre de la sucursal

                        row++; // Incrementar el contador de filas
                    }

                    // Configurar la respuesta para descargar el archivo
                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    var fileName = "Auditorias.xlsx";
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