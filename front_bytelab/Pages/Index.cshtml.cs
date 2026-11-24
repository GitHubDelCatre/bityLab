using front_bytelab.nucleo;
using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;

        public IndexModel(IUsuariosPresentacion IUsuariosPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
        }

        public bool EstaLogueado = false;
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contrasena { get; set; }

        public void OnGet(string? denegado)
        {
            EstaLogueado = Sesion.EstaLogueado(HttpContext);
            if (EstaLogueado && !string.IsNullOrEmpty(denegado))
                ViewData["Mensaje"] = "Su rol no tiene permiso para entrar a: " + denegado;
        }

        public void OnPostBtLimpiar()
        {
            Correo = string.Empty;
            Contrasena = string.Empty;
        }

        public void OnPostBtEntrar()
        {
            try
            {
                var usuario = this.IUsuariosPresentacion.Login(new Usuarios()
                {
                    Correo = Correo,
                    Contrasena = Contrasena
                });
                Sesion.Iniciar(HttpContext, usuario);
                EstaLogueado = true;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IActionResult OnPostBtCerrar()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
