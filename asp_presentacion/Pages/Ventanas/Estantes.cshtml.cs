using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class EstantesModel : PageModel
    {
        private IEstantesPresentacion? iPresentacion = null;
        private ICategoriasPresentacion? iCategoriasPresentacion = null;
        private IBodegasPresentacion? iBodegasPresentacion = null;

        public EstantesModel(IEstantesPresentacion iPresentacion, IBodegasPresentacion iBodegasPresentacion, ICategoriasPresentacion iCategoriasPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iCategoriasPresentacion = iCategoriasPresentacion;
                this.iBodegasPresentacion = iBodegasPresentacion;
                Filtro = new Estantes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Estantes? Actual { get; set; }
        [BindProperty] public Estantes? Filtro { get; set; }
        [BindProperty] public List<Estantes>? Lista { get; set; }
        [BindProperty] public List<Bodegas>? Bodegas { get; set; }
        [BindProperty] public List<Categorias>? Categorias { get; set; }

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
                CargarComboxBod();
                CargarComboxCat();
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
                CargarComboxBod();
                CargarComboxCat();
                Actual = new Estantes()
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
                CargarComboxBod();
                CargarComboxCat();
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
                Task<Estantes>? task = null;
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

        public void CargarComboxBod()
        {
            try
            {
                if (!(Bodegas == null || Bodegas!.Count <= 0))
                    return;

                var task = this.iBodegasPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Bodegas = JsonConversor.ConvertirAObjeto<List<Bodegas>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipoBod(int id)
        {
            try
            {
                CargarComboxBod();
                return Bodegas!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public void CargarComboxCat()
        {
            try
            {
                if (!(Categorias == null || Categorias!.Count <= 0))
                    return;

                var task = this.iCategoriasPresentacion!.Listar(HttpContext.Session.GetString("Token")!);
                task.Wait();
                Categorias = JsonConversor.ConvertirAObjeto<List<Categorias>>(JsonConversor.ConvertirAString(task.Result));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirTipoCat(int id)
        {
            try
            {
                CargarComboxCat();
                return Categorias!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
    }
}