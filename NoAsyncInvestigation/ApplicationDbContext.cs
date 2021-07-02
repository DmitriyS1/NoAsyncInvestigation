using Microsoft.EntityFrameworkCore;

namespace NoAsyncInvestigation
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opt)
            => opt.UseNpgsql("");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Model> Models { get; set; }
    }
}
