using Microsoft.EntityFrameworkCore;
using FacturadorDomain.Entities;

namespace FacturadorInfrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<FacturaCabecera> FacturaCabecera { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FacturaConMontoTotal>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_FacturasConMontoTotal");
            });

            modelBuilder.Entity<FacturaConCliente>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VW_FacturasConCliente");
            });
        }
    }
}
