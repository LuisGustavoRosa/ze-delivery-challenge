using Microsoft.EntityFrameworkCore;
using ze_delivery_challenge.Domain.Entities;

namespace ze_delivery_challenge.Infra
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Partner> Partners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("sua connection string aqui");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partner>()
              .HasIndex(u => u.Document)
              .IsUnique();
        }
    }
}
