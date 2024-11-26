using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class BodegasModel : PageModel
    {
        private IBodegasPresentacion? iPresentacion = null;
        private ISucursalesPresentacion? iSucursalesPresentacion = null;

        public BodegasModel(IBodegasPresentacion iPresentacion, ISucursalesPresentacion iSucursalesPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iSucursalesPresentacion = iSucursalesPresentacion;
                Filtro = new Bodegas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Bodegas? Actual { get; set; }
        [BindProperty] public Bodegas? Filtro { get; set; }
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
                if (Actual!.Id == 0)
                    task = iPresentacion!.Guardar(Actual!, HttpContext.Session.GetString("Token")!);
                else
                    task = iPresentacion!.Modificar(Actual!, HttpContext.Session.GetString("Token")!);
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
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
                var task = iPresentacion!.Borrar(Actual!, HttpContext.Session.GetString("Token")!);
                Actual = task.Result;
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
    }
}