using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class UsuariosModel : PageModel
    {
        private IUsuariosPresentacion? iPresentacion = null;
        private IRolesPresentacion? iRolesPresentacion = null;
        private IAuditoriasPresentacion? iAuditoria = null;

        public UsuariosModel(IUsuariosPresentacion iPresentacion, IRolesPresentacion iRolesPresentacion, IAuditoriasPresentacion iAuditoria)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iRolesPresentacion = iRolesPresentacion; ;
                Filtro = new Usuarios();
                this.iAuditoria = iAuditoria;
                Auditoria = new Auditorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public Usuarios? Filtro { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public List<Usuarios>? Lista { get; set; }
        [BindProperty] public List<Roles>? Roles { get; set; }



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
                CargarCombox();
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
                CargarCombox();
                Actual = new Usuarios()
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
                Task<Usuarios>? task = null;
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
                CargarCombox();
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
                CargarCombox();
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
        public void CargarCombox()
        {
            try
            {
                if (!(Roles == null || Roles!.Count <= 0))
                    return;

                var task = this.iRolesPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Roles = JsonConversor.ConvertirAObjeto<List<Roles>>(JsonConversor.ConvertirAString(task.Result));
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
                return Roles!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
    }
}