using System.Text.Json;
using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Auditoria = lib_bytelab.entidades.Auditorias;

namespace lib_bytelab.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; } = DatosGenerales.StringConexion();

        /// <summary>Correo del usuario que hace el cambio (llega desde el front en el header "Usuario").</summary>
        public string? UsuarioActual { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nunca borrar en cascada: si un registro tiene hijos no se deja borrar
            foreach (var llave in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                llave.DeleteBehavior = DeleteBehavior.Restrict;
        }

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

        public bool PuedeConectar()
        {
            return this.Database.CanConnect();
        }

        /// <summary>
        /// Auditoría automática para TODAS las entidades: cada vez que se inserta,
        /// actualiza o borra algo, se guarda un registro en la tabla Auditorias.
        /// </summary>
        public override int SaveChanges()
        {
            var cambios = this.ChangeTracker.Entries()
                .Where(x => x.Entity is EntidadBase && x.Entity is not Auditoria &&
                    (x.State == EntityState.Added ||
                     x.State == EntityState.Modified ||
                     x.State == EntityState.Deleted))
                .Select(x => new { Entrada = x, Accion = Traducir(x.State), Datos = Serializar(x) })
                .ToList();

            var resultado = base.SaveChanges();

            if (cambios.Count > 0)
            {
                foreach (var cambio in cambios)
                {
                    this.Auditorias!.Add(new Auditoria()
                    {
                        Entidad = cambio.Entrada.Entity.GetType().Name,
                        Accion = cambio.Accion,
                        IdRegistro = ((EntidadBase)cambio.Entrada.Entity).Id,
                        Usuario = string.IsNullOrWhiteSpace(this.UsuarioActual) ? "sistema" : this.UsuarioActual,
                        Fecha = DateTime.Now,
                        Datos = cambio.Datos
                    });
                }
                base.SaveChanges();
            }

            // Se limpia el seguimiento para que cada operación empiece desde cero
            this.ChangeTracker.Clear();
            return resultado;
        }

        private static string Traducir(EntityState estado)
        {
            return estado switch
            {
                EntityState.Added => "Insertar",
                EntityState.Modified => "Actualizar",
                EntityState.Deleted => "Borrar",
                _ => estado.ToString()
            };
        }

        private static string Serializar(EntityEntry entrada)
        {
            var datos = new Dictionary<string, object?>();
            foreach (var propiedad in entrada.Properties)
            {
                var nombre = propiedad.Metadata.Name;
                if (nombre == "Id" || nombre == "ContrasenaHash")
                    continue;
                var valor = entrada.State == EntityState.Deleted ? propiedad.OriginalValue : propiedad.CurrentValue;
                if (nombre == "Imagen" && valor != null)
                    valor = "[imagen]";
                datos[nombre] = valor;
            }
            return JsonSerializer.Serialize(datos);
        }
    }
}
