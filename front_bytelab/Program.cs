using System.Globalization;
using front_bytelab.nucleo;
using Microsoft.AspNetCore.Localization;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.Name = ".ByteLab.Sesion";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IReportes, Reportes>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IRolesPermisosPresentacion, RolesPermisosPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
builder.Services.AddScoped<ISucursalesPresentacion, SucursalesPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();
builder.Services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IResenasPresentacion, ResenasPresentacion>();
builder.Services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IComprasProductosPresentacion, ComprasProductosPresentacion>();
builder.Services.AddScoped<IDetallesOrdenesComprasPresentacion, DetallesOrdenesComprasPresentacion>();
builder.Services.AddScoped<IPromocionesPresentacion, PromocionesPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
builder.Services.AddScoped<IDetallesVentasPresentacion, DetallesVentasPresentacion>();
builder.Services.AddScoped<IMetodosPagoPresentacion, MetodosPagoPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IDevolucionesPresentacion, DevolucionesPresentacion>();
builder.Services.AddScoped<IGarantiasPresentacion, GarantiasPresentacion>();
builder.Services.AddScoped<IEmpresasPaqueteriaPresentacion, EmpresasPaqueteriaPresentacion>();
builder.Services.AddScoped<IEnviosPresentacion, EnviosPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Cultura invariante: los decimales viajan con punto (1500.50) en formularios y JSON
var cultura = CultureInfo.InvariantCulture;
app.UseRequestLocalization(new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(cultura),
    SupportedCultures = new List<CultureInfo>() { cultura },
    SupportedUICultures = new List<CultureInfo>() { cultura }
});

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
