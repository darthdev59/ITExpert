using ITExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ValueEntity> Values => Set<ValueEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValueEntity>()
                .HasKey(k => k.Row);
            modelBuilder.Entity<ValueEntity>()
                .Property(k => k.Row).ValueGeneratedNever();
        }
    }
}
