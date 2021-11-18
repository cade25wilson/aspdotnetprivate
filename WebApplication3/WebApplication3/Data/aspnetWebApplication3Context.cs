using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication3.Models;

#nullable disable

namespace WebApplication3.Data
{
    public partial class aspnetWebApplication3Context : DbContext
    {
        public aspnetWebApplication3Context()
        {
        }

        public aspnetWebApplication3Context(DbContextOptions<aspnetWebApplication3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApplication3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COLOR");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterId)
                    .HasMaxLength(450)
                    .HasColumnName("Poster_ID ");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SellEndDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SELL END DATE");

                entity.Property(e => e.ShippingMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPPING METHOD");

                entity.Property(e => e.ShippingPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SHIPPING PRICE");

                entity.HasOne(d => d.Poster)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PosterId)
                    .HasConstraintName("FK_Product_AspNetUsers_POSTER_ID");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image1).HasColumnType("image");

                entity.Property(e => e.Image10).HasColumnType("image");

                entity.Property(e => e.Image2).HasColumnType("image");

                entity.Property(e => e.Image3).HasColumnType("image");

                entity.Property(e => e.Image4).HasColumnType("image");

                entity.Property(e => e.Image5)
                    .HasColumnType("image")
                    .HasColumnName("image5");

                entity.Property(e => e.Image6).HasColumnType("image");

                entity.Property(e => e.Image7).HasColumnType("image");

                entity.Property(e => e.Image8).HasColumnType("image");

                entity.Property(e => e.Image9).HasColumnType("image");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
