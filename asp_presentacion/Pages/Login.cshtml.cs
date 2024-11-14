using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace asp_presentacion.Pages
{
    public class LoginModel : PageModel
    {
        private ILoginPresentacion? iPresentacion = null;

        public LoginModel(ILoginPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                UsuarioActual = new Usuarios();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Usuarios? UsuarioActual { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }

        public void OnGet()
        {
        }

        //METODO A MODIFICAR A FUTURO
        public ActionResult OnPost()
        {
            
            Task<string> task = iPresentacion!.Autenticar(UsuarioActual!);
            task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                return Redirect("/Home");

                }
                return Redirect("/Privacy");

        }
    }
}
