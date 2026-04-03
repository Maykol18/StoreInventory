using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Data;

public partial class InventarioDbContext : DbContext
{
    public InventarioDbContext()
    {
    }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=gotaku16;Database=InventarioDb");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria", "inventario");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orden_pkey");

            entity.ToTable("orden", "inventario");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Totalamount)
                .HasColumnType("money")
                .HasColumnName("totalamount");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderitem_pkey");

            entity.ToTable("order_items", "inventario");

            entity.HasIndex(e => e.Orderid, "IX_order_items_orderid");

            entity.HasIndex(e => e.Productid, "IX_order_items_productid");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("item_orderid_id");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orderitem_productid_id");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("producto_pkey");

            entity.ToTable("producto", "inventario");

            entity.HasIndex(e => e.CategoriaId, "IX_producto_CategoriaId");

            entity.HasIndex(e => e.ProveedorId, "IX_producto_ProveedorId");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("producto_categoriaid_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("producto_proveedorid_id");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedor_pkey");

            entity.ToTable("proveedor", "inventario");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
