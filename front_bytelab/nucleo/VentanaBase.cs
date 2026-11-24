using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using Microsoft.AspNetCore.Mvc;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.nucleo
{
    /// <summary>
    /// Ventana genérica de mantenimiento (CRUD) con el mismo funcionamiento de la ventana
    /// "Asignaciones" del profe: Consultar, Nuevo, Guardar, Editar, Borrar + PDF y Excel.
    /// Cada ventana hereda de aquí y solo agrega sus listas desplegables.
    /// </summary>
    public abstract class VentanaBase<T> : PaginaSegura where T : EntidadBase, new()
    {
        protected IPresentacionBase<T> IPresentacion;
        protected IReportes IReportes;

        protected VentanaBase(IPresentacionBase<T> IPresentacion, IReportes IReportes)
        {
            this.IPresentacion = IPresentacion;
            this.IReportes = IReportes;
            this.Filtro = new T();
        }

        public override string Permiso => typeof(T).Name;
        public abstract string Titulo { get; }
        public virtual bool SoloLectura => false;

        [BindProperty] public IFormFile? FormFile { get; set; }
        [BindProperty] public T? Filtro { get; set; }
        [BindProperty] public T? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        public List<T> Lista { get; set; } = new List<T>();

        /// <summary>Carga las listas de los select (llaves foráneas).</summary>
        protected virtual void CargarListas() { }

        /// <summary>Valores por defecto de un registro nuevo.</summary>
        protected virtual void Inicializar(T entidad) { }

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Formulario = false;
                Borrar = false;
                CargarLista();
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
                if (SoloLectura)
                    return;
                Formulario = true;
                this.Actual = new T();
                Inicializar(this.Actual);
                CargarListas();
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
                if (SoloLectura || this.Actual == null)
                    return;

                if (FormFile != null && this.Actual is IConImagen conImagen)
                {
                    using var memoryStream = new MemoryStream();
                    FormFile.CopyTo(memoryStream);
                    conImagen.Imagen = Convert.ToBase64String(memoryStream.ToArray());
                }

                if (this.Actual.Id == 0)
                    this.Actual = this.IPresentacion.Insertar(this.Actual);
                else
                    this.Actual = this.IPresentacion.Actualizar(this.Actual);

                ViewData["Exito"] = "Registro guardado correctamente";
                Formulario = false;
                CargarLista();
            }
            catch (Exception ex)
            {
                // Si falla se deja el formulario abierto con lo que el usuario escribió
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                try { CargarListas(); } catch { }
            }
        }

        public virtual void OnPostBtEditar(string data)
        {
            try
            {
                CargarLista();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                Formulario = this.Actual != null;
                CargarListas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtPregBorrar(string data)
        {
            try
            {
                CargarLista();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                Borrar = this.Actual != null;
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
                if (SoloLectura || this.Actual == null || this.Actual.Id == 0)
                    return;
                this.IPresentacion.Borrar(this.Actual);
                ViewData["Exito"] = "Registro borrado";
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                Borrar = false;
                try { CargarLista(); } catch { }
            }
        }

        public IActionResult OnPostBtPdf()
        {
            try
            {
                CargarLista();
                return File(this.IReportes.Pdf(Titulo, this.Lista), "application/pdf", typeof(T).Name + ".pdf");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }

        public IActionResult OnPostBtExcel()
        {
            try
            {
                CargarLista();
                return File(this.IReportes.Excel(Titulo, this.Lista),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", typeof(T).Name + ".xlsx");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }

        protected void CargarLista()
        {
            this.Filtro ??= new T();
            this.Lista = this.IPresentacion.Buscar(this.Filtro);
        }
    }
}
