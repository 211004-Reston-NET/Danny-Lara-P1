using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserInterface.Entities
{
    public partial class _211004RestonNetLaraContext : DbContext
    {
        public _211004RestonNetLaraContext()
        {
        }

        public _211004RestonNetLaraContext(DbContextOptions<_211004RestonNetLaraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__customer__A1B71F9059D12E89");

                entity.ToTable("customer");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.CustAddress)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("cust_address");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cust_phone_number");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lineItem");

                entity.Property(e => e.LineItemQuantity).HasColumnName("lineItem_quantity");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.OrderNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.OrderNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lineItem__order___40058253");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lineItem__produc__40F9A68C");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("PK__orders__730E34DE33F1E9DC");

                entity.ToTable("orders");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.OrderTotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("order_total_price");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__cust_id__3D2915A8");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__store_id__3E1D39E1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("product_price");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__store_i__3A4CA8FD");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
