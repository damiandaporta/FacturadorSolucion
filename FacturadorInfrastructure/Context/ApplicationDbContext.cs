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
    }
}
