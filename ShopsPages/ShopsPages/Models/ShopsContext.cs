using Microsoft.EntityFrameworkCore;

namespace ShopsPages.Models
{
    public class ShopsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public ShopsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShopsPagesDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop { Id = 0, Address = "Minsk", WorkingHours = "24/7" },
                new Shop { Id = 1, Address = "Vitebsk", WorkingHours = "12:00-22:00" },
                new Shop { Id = 2, Address = "Gomel", WorkingHours = "9:00-20:00" }
                );

            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity.HasOne(p => p.Shop)
                    .WithMany(s => s.Products)
                    .HasForeignKey("ShopId");
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 0, ShopId = 0, Name = "Orange", Description = "Orange and tasty" },
                new Product { Id = 1, ShopId = 0, Name = "Milk", Description = "Cow and fresh" },
                new Product { Id = 2, ShopId = 1, Name = "Pen", Description = "Stylish and expensive" },
                new Product { Id = 3, ShopId = 1, Name = "Pencil case", Description = "Red and big" },
                new Product { Id = 4, ShopId = 2, Name = "Fork", Description = "Sharp and silver" },
                new Product { Id = 5, ShopId = 2, Name = "Spoon", Description = "Practical and gold" }
                );

        }
    }
}
