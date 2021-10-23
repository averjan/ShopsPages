using Microsoft.EntityFrameworkCore;

namespace ShopsPages.Models
{
    public class ShopsContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Shop>? Shops { get; set; }
        public ShopsContext() : base()
        {
            Database.EnsureCreated();
        }

        public ShopsContext(DbContextOptions<ShopsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop { ShopId = 1, Name = "Fix Price", Address = "Minsk", WorkingHours = "24/7" },
                new Shop { ShopId = 2, Name = "Gippo", Address = "Vitebsk", WorkingHours = "12:00-22:00" },
                new Shop { ShopId = 3, Name = "Evroopt", Address = "Gomel", WorkingHours = "9:00-20:00" }
            );
            
            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity.HasOne(p => p.Shop)
                                .WithMany(s => s.Products)
                                .HasForeignKey("ShopId").IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ShopId = 1, Name = "Orange", Description = "Orange and tasty" },
                new Product { ProductId = 2, ShopId = 1, Name = "Milk", Description = "Cow and fresh" },
                new Product { ProductId = 3, ShopId = 2, Name = "Pen", Description = "Stylish and expensive" },
                new Product { ProductId = 4, ShopId = 2, Name = "Pencil case", Description = "Red and big" },
                new Product { ProductId = 5, ShopId = 3, Name = "Fork", Description = "Sharp and silver" },
                new Product { ProductId = 6, ShopId = 3, Name = "Spoon", Description = "Practical and gold" }
            );
        }
    }
}
