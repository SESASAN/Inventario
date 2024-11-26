using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class LotesModel : PageModel
    {
        private ILotesPresentacion? iPresentacion = null;
        private IProductosPresentacion? iProductosPresentacion = null;
        private IEstadosPresentacion? iEstadosPresentacion = null;
        private IProveedoresPresentacion? iProveedoresPresentacion = null;

        public LotesModel(ILotesPresentacion iPresentacion, IProductosPresentacion iProductosPresentacion, IEstadosPresentacion iEstadosPresentacion, IProveedoresPresentacion iProveedoresPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iProductosPresentacion=iProductosPresentacion;
                this.iEstadosPresentacion= iEstadosPresentacion;
                this.iProveedoresPresentacion= iProveedoresPresentacion;
                Filtro = new Lotes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Lotes? Actual { get; set; }
        [BindProperty] public Lotes? Filtro { get; set; }
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
                OnPostBtRefrescar();
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
    }
}