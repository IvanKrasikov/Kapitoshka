
namespace Kapitoshka.Models
{
    using Microsoft.EntityFrameworkCore;
    public class NodeContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; } = null!;
        public NodeContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12341234");
        }
    }
}
