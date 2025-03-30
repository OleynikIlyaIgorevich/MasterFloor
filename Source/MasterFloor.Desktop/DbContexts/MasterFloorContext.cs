using System;
using System.Collections.Generic;
using MasterFloor.Desktop.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MasterFloor.Desktop.DbContexts;

public partial class MasterFloorContext : DbContext
{
    public MasterFloorContext()
    {
    }

    public MasterFloorContext(DbContextOptions<MasterFloorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=master_floor;user=root;password=12032003", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("material_types");

            entity.HasIndex(e => e.Title, "title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RejectionRate)
                .HasPrecision(5, 2)
                .HasColumnName("rejection_rate");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partners");

            entity.HasIndex(e => e.Address, "address").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Inn, "inn").IsUnique();

            entity.HasIndex(e => e.PartnerTypeId, "partner_type_id");

            entity.HasIndex(e => e.Phone, "phone").IsUnique();

            entity.HasIndex(e => e.Title, "title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.DirectorFirstname)
                .HasMaxLength(64)
                .HasColumnName("director_firstname");
            entity.Property(e => e.DirectorLastname)
                .HasMaxLength(64)
                .HasColumnName("director_lastname");
            entity.Property(e => e.DirectorMiddlename)
                .HasMaxLength(64)
                .HasColumnName("director_middlename");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasMaxLength(32)
                .HasColumnName("inn");
            entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(32)
                .HasColumnName("phone");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");

            entity.HasOne(d => d.PartnerType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partners_ibfk_1");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partner_products");

            entity.HasIndex(e => e.PartnerId, "partner_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SellAt).HasColumnName("sell_at");
            entity.Property(e => e.SellPrice)
                .HasPrecision(10)
                .HasColumnName("sell_price");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_ibfk_1");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partner_types");

            entity.HasIndex(e => e.Title, "title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.Articul, "articul").IsUnique();

            entity.HasIndex(e => e.ProductTypeId, "product_type_id");

            entity.HasIndex(e => e.Title, "title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articul)
                .HasMaxLength(32)
                .HasColumnName("articul");
            entity.Property(e => e.MinimalPrice)
                .HasPrecision(10)
                .HasColumnName("minimal_price");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product_types");

            entity.HasIndex(e => e.Title, "title").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductTypeFactor)
                .HasPrecision(5, 2)
                .HasColumnName("product_type_factor");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
