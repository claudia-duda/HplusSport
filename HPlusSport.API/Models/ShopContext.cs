using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(category =>category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);
            modelBuilder.Entity<Order>().HasMany(order => order.Products);
            modelBuilder.Entity<Order>().HasOne(order => order.User);
            modelBuilder.Entity<User>()
                .HasMany(user => user.Orders)
                .WithOne(order => order.User)
                .HasForeignKey(user => user.UserId);

            modelBuilder.Seed();
        }
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

    
    }
}
