using lib_aplicaciones.Interfaces;
using asp_servicios.Nucleo;
using lib_entidades.Modelos;
using lib_utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace asp_servicios.Controllers
{
    public class TokenController : ControllerBase
    {
        private IUsuariosAplicacion? iAplicacion = null;
        public TokenController(IUsuariosAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
                if (string.IsNullOrEmpty(datos))
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return respuesta;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Token/Autenticar")]
        public string Autenticar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                var UsuarioIngresado = new Usuarios()
                {
                    Nombre_Usuario = EncriptarConversor.Encriptar(datos["Usuario"].ToString()!),
                    Clave = EncriptarConversor.Encriptar(datos["Clave"].ToString()!)
                };
                var listausuarios = iAplicacion!.Buscar(UsuarioIngresado, "NOMBRE_USUARIO");
                if (listausuarios.IsNullOrEmpty())
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                // Logica de aplicación
                var Usuariobbd = listausuarios.FirstOrDefault(x => x.Nombre_Usuario == UsuarioIngresado.Nombre_Usuario);

                if (!datos.ContainsKey("Usuario") || !datos.ContainsKey("Clave")||
                UsuarioIngresado!.Nombre_Usuario != Usuariobbd!.Nombre_Usuario! ||
                UsuarioIngresado!.Clave != Usuariobbd!.Clave!
                )
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, datos["Usuario"].ToString()!)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DatosGenerales.clave)), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                respuesta["Token"] = tokenHandler.WriteToken(token);
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        public bool Validate(Dictionary<string, object> data)
        {
            try
            {
                var authorizationHeader = data["Bearer"].ToString();
                authorizationHeader = authorizationHeader!.Replace("Bearer ", "");
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken token = tokenHandler.ReadToken(authorizationHeader);
                if (DateTime.UtcNow > token.ValidTo)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


