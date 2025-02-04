using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Entities;

namespace SalesApp.Infrastructure.DataContext
{
    public class SalesAppDataContext: DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<User> Users { get; set; }


        public SalesAppDataContext(DbContextOptions<SalesAppDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.date).IsRequired();
                entity.HasOne<User>(ci => ci.user).WithMany(f => f.carts).HasForeignKey(ci => ci.userId);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(ci => new { ci.cartId, ci.productId });
                entity.Property(ci => ci.quantity).IsRequired();
                entity.HasOne<Cart>(ci => ci.cart).WithMany(f => f.products).HasForeignKey(ci => ci.cartId);
                entity.HasOne<Product>(ci => ci.product).WithMany(f => f.carts).HasForeignKey(ci => ci.productId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.title).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.price).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.description).IsRequired(false).HasMaxLength(5000);
                entity.Property(e => e.category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.image).IsRequired(false).HasMaxLength(5000);
                entity.ComplexProperty(e => e.rating);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.date).IsRequired();
                entity.HasOne<User>(ci => ci.user).WithMany(f => f.sales).HasForeignKey(ci => ci.userId);
                entity.Property(e => e.totalProductAmount).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.totalDiscountAmount).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.totalSaleAmount).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.branch).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(ci => new { ci.saleId, ci.productId });
                entity.Property(ci => ci.quantity).IsRequired();
                entity.Property(ci => ci.price).IsRequired().HasPrecision(18, 2);
                entity.Property(ci => ci.discount).IsRequired().HasPrecision(18, 2);
                entity.Property(ci => ci.total).IsRequired().HasPrecision(18, 2);
                entity.HasOne<Sale>(ci => ci.sale).WithMany(f => f.products).HasForeignKey(ci => ci.saleId);
                entity.HasOne<Product>(ci => ci.product).WithMany(f => f.sales).HasForeignKey(ci => ci.productId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.email).IsRequired().HasMaxLength(300);
                entity.Property(e => e.username).IsRequired().HasMaxLength(300);
                entity.Property(e => e.password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.phone).IsRequired().HasMaxLength(30);
                entity.ComplexProperty(e => e.name);
                entity.ComplexProperty(e => e.address, b => b.ComplexProperty(e => e.geolocation));
            });
        }
    }
}
