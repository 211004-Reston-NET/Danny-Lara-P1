using Microsoft.EntityFrameworkCore;
using Models;

#nullable disable

namespace DataAccessLogic
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItems> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustID)
                    .HasName("PK__customer__A1B71F90DD81F00C");

                entity.ToTable("customer");

                entity.Property(e => e.CustID).HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("cust_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cust_phone_number");
            });

            modelBuilder.Entity<LineItems>(entity =>
            {
                entity.HasKey(e => e.LineItemId).HasName("lineItem_id");

                entity.ToTable("lineItem");

                entity.Property(e => e.LineItemId).HasColumnName("lineItem_id");

                entity.Property(e => e.Quantity).HasColumnName("lineItem_quantity");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.ProductID).HasColumnName("product_id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("PK__orders__730E34DE09B91646");

                entity.ToTable("orders");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.CustID).HasColumnName("customer_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("order_total_price");

                entity.Property(e => e.StoreID).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__store_id__4B7734FF");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductID).HasColumnName("product_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("product_price");

                entity.Property(e => e.Quantity).HasColumnName("product_quantity");

                entity.Property(e => e.StoreID).HasColumnName("store_id");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.StoreID).HasColumnName("store_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.Name)
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
