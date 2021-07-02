using Microsoft.EntityFrameworkCore;

namespace NoAsyncInvestigation
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opt)
            => opt.UseNpgsql("Host=localhost;Port=5444;Database=async;Username=back;Password=dristPasswd");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Model> Models { get; set; }
    }
}
