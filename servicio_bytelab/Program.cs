using System.Diagnostics;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Conexión a la base de datos (se puede cambiar en appsettings.json)
var cadena = builder.Configuration.GetConnectionString("ByteLab") ?? DatosGenerales.StringConexion();
builder.Services.AddScoped<IConexion>(sp => new Conexion() { StringConexion = cadena });

builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IRolesPermisosAplicacion, RolesPermisosAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
builder.Services.AddScoped<ISucursalesAplicacion, SucursalesAplicacion>();
builder.Services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<ICategoriasAplicacion, CategoriasAplicacion>();
builder.Services.AddScoped<IMarcasAplicacion, MarcasAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<IResenasAplicacion, ResenasAplicacion>();
builder.Services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
builder.Services.AddScoped<IComprasProductosAplicacion, ComprasProductosAplicacion>();
builder.Services.AddScoped<IDetallesOrdenesComprasAplicacion, DetallesOrdenesComprasAplicacion>();
builder.Services.AddScoped<IPromocionesAplicacion, PromocionesAplicacion>();
builder.Services.AddScoped<IVentasAplicacion, VentasAplicacion>();
builder.Services.AddScoped<IDetallesVentasAplicacion, DetallesVentasAplicacion>();
builder.Services.AddScoped<IMetodosPagoAplicacion, MetodosPagoAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
builder.Services.AddScoped<IDevolucionesAplicacion, DevolucionesAplicacion>();
builder.Services.AddScoped<IGarantiasAplicacion, GarantiasAplicacion>();
builder.Services.AddScoped<IEmpresasPaqueteriaAplicacion, EmpresasPaqueteriaAplicacion>();
builder.Services.AddScoped<IEnviosAplicacion, EnviosAplicacion>();

var app = builder.Build();

// Cualquier error se devuelve como texto para que el front lo muestre
app.UseExceptionHandler(errorApp => errorApp.Run(async contexto =>
{
    var error = contexto.Features.Get<IExceptionHandlerFeature>()?.Error;
    contexto.Response.StatusCode = StatusCodes.Status400BadRequest;
    contexto.Response.ContentType = "text/plain; charset=utf-8";
    await contexto.Response.WriteAsync(LogConversor.Mensaje(error));
}));

// Monitoreo: registra cuánto tarda cada petición
app.Use(async (contexto, siguiente) =>
{
    var reloj = Stopwatch.StartNew();
    var conexion = contexto.RequestServices.GetRequiredService<IConexion>();
    conexion.UsuarioActual = contexto.Request.Headers["Usuario"].FirstOrDefault();
    await siguiente();
    reloj.Stop();
    app.Logger.LogInformation("{Metodo} {Ruta} -> {Estado} en {Ms} ms",
        contexto.Request.Method, contexto.Request.Path, contexto.Response.StatusCode, reloj.ElapsedMilliseconds);
});

app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "ByteLab API funcionando");
app.MapGet("/salud", (IConexion conexion) => Results.Ok(new
{
    estado = "ok",
    baseDeDatos = conexion.PuedeConectar() ? "conectada" : "sin conexión",
    hora = DateTime.Now
}));
app.Run();
