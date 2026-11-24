using lib_bytelab.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_bytelab.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        string? UsuarioActual { get; set; }

        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<RolesPermisos>? RolesPermisos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Resenas>? Resenas { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<ComprasProductos>? ComprasProductos { get; set; }
        public DbSet<DetallesOrdenesCompras>? DetallesOrdenesCompras { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<DetallesVentas>? DetallesVentas { get; set; }
        public DbSet<MetodosPago>? MetodosPago { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Garantias>? Garantias { get; set; }
        public DbSet<EmpresasPaqueteria>? EmpresasPaqueteria { get; set; }
        public DbSet<Envios>? Envios { get; set; }

        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        bool PuedeConectar();
    }
}
