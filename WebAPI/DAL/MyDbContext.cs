using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal type for OrderDetail.UnitPrice
            modelBuilder.Entity<OrderDetail>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            // Configure relationships and constraints
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CreatedByUser)
                .WithMany(u => u.CreatedOrders)
                .HasForeignKey(o => o.CreatedByUserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust if needed

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ProcessedByUser)
                .WithMany(u => u.ProcessedOrders)
                .HasForeignKey(o => o.ProcessedByUserId)
                .OnDelete(DeleteBehavior.SetNull); // Adjust if needed
        }
    }
}
