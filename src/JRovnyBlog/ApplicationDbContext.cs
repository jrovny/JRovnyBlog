using Microsoft.EntityFrameworkCore;

namespace JRovnyBlog
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConnectionService _connectionService;
        
        public ApplicationDbContext(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public DbSet<Data.Models.Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_connectionService.GetDefaultConnectionString());
        }
    }
}