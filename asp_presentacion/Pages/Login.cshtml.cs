using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentacion.Pages
{
    public class LoginModel : PageModel
    {
        private ILoginPresentacion? iPresentacion = null;
        private IUsuariosPresentacion? iUsuario = null;

        public LoginModel(ILoginPresentacion iPresentacion, IUsuariosPresentacion iUsuario)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iUsuario = iUsuario;
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

            try
            {
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var token = task.Result;
                    UsuarioActual!.Nombre = UsuarioActual!.Nombre ?? "";
                    var User = this.iUsuario!.Buscar(UsuarioActual!, "NOMBRE_USUARIO_ENCRIPTADO", token);
                    User.Wait();
                    var Lista = User.Result;

                    HttpContext.Session.SetInt32("ID", Lista!.FirstOrDefault(x => x.Nombre_Usuario!.ToString() == EncriptarConversor.Encriptar(UsuarioActual.Nombre_Usuario!))!.Id);
                    HttpContext.Session.SetString("Usuario", UsuarioActual!.Nombre_Usuario!);
                    HttpContext.Session.SetString("Clave", UsuarioActual!.Clave!);
                    HttpContext.Session.SetString("Permisos", Lista!.FirstOrDefault(x => x.Nombre_Usuario!.ToString() == EncriptarConversor.Encriptar(UsuarioActual.Nombre_Usuario!))!._Rol!.Permiso!.ToString());
                    HttpContext.Session.SetString("Token", token);

                    return Redirect("/Home");

                } else
                {
                    return OnPostBtRefrescar();
                }

            } catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return OnPostBtRefrescar();
            }
            
        }

        public ActionResult OnPostBtRefrescar()
        {
            return Redirect("/");
        }
    }
}
