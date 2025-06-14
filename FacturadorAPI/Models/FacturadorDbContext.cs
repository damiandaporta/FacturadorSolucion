using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI.Models;

public partial class FacturadorDbContext : DbContext
{
    public FacturadorDbContext()
    {
    }

    public FacturadorDbContext(DbContextOptions<FacturadorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FacturadorDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.ArtId).HasName("PK__Articulo__FD7CB5B27247599F");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliId).HasName("PK__Cliente__83531C5A2B97BF15");
        });

        modelBuilder.Entity<FacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.FactId).HasName("PK__Factura___8327E007A3CA0843");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.FactDtlId).HasName("PK__Factura___79874B1BF72B63D8");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
