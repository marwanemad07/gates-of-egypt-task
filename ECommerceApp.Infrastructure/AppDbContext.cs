using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // we may use configurations here, but for now, i'm using data annotations
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    r => r.ToString(),
                    r => (UserRole)Enum.Parse(typeof(UserRole), r)
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
