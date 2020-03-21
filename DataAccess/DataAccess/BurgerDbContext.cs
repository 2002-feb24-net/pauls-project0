using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DataAccess
{
    public partial class BurgerDbContext : DbContext
    {
        public BurgerDbContext()
        {
        }

        public BurgerDbContext(DbContextOptions<BurgerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SecretConfiguration.connecctionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FavoriteItem).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.FavoriteStore)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.FavoriteStoreId)
                    .HasConstraintName("FK__Customers__Favor__4BAC3F29");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHist__Custo__5FB337D6");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHist__Store__60A75C0F");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Score).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(280);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__Custome__4F7CD00D");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ReviewsNavigation)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__StoreId__4E88ABD4");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.Property(e => e.AvgReviewScore).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
