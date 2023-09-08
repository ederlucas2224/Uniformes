using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaUniformes.Models;

namespace SistemaUniformes.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Grupos> Grupos { get; set; }

    public virtual DbSet<Ordenes> Ordenes { get; set; }

    public virtual DbSet<OrdenesEntrada> OrdenesEntrada { get; set; }

    public virtual DbSet<OrdenesSalida> OrdenesSalida { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Tipos> Tipos { get; set; }

    public virtual DbSet<TablaPivote> TablaPivotes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=LAPTOP-UCH56F9I;initial catalog=Uniformes;persist security info=True;user id=Eder;password=Sonricss22;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TablaPivote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TablaPiv__3214EC07AD5BC8E4");

            entity.ToTable("TablaPivote");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E127F3B9C");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK__Empleados__IdGru__3C69FB99");
        });

        modelBuilder.Entity<Grupos>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupos__303F6FD9E3415815");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Grupos__IdTipo__398D8EEE");
        });

        modelBuilder.Entity<Ordenes>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK__Ordenes__C38F300D6CBA8432");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrdenesEntrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenesE__3214EC07697B079B");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.OrdenesEntrada)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("FK__OrdenesEn__IdOrd__48CFD27E");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenesEntrada)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__OrdenesEn__IdPro__4E88ABD4");
        });

        modelBuilder.Entity<OrdenesSalida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenesS__3214EC07B5275D56");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.OrdenesSalida)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__OrdenesSa__IdEmp__45F365D3");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.OrdenesSalida)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("FK__OrdenesSa__IdOrd__440B1D61");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenesSalida)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__OrdenesSa__IdPro__4D94879B");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892105737F209");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Productos__IdTip__4CA06362");
        });

        modelBuilder.Entity<Tipos>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipo__9E3A29A547925CE1");

            entity.ToTable("Tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
