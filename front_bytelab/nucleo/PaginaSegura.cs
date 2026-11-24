using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_bytelab.nucleo
{
    /// <summary>
    /// Página que exige sesión iniciada y permiso del rol.
    /// Se revisa antes de ejecutar cualquier handler (OnGet, OnPostBt...).
    /// </summary>
    public abstract class PaginaSegura : PageModel
    {
        public abstract string Permiso { get; }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!Sesion.EstaLogueado(HttpContext))
            {
                context.Result = RedirectToPage("/Index");
                return;
            }

            if (!Sesion.TienePermiso(HttpContext, Permiso))
            {
                context.Result = RedirectToPage("/Index", new { denegado = Permiso });
                return;
            }

            base.OnPageHandlerExecuting(context);
        }
    }
}
