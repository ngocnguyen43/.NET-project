using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity=>
            {
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
                entity.Property(m=> m.updatedAt).ValueGeneratedOnAddOrUpdate();
                entity.Property(m=>m.createdAt).ValueGeneratedOnAdd();
            });
        }
    }
}
