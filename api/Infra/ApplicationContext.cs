using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infra
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(6, 0, 1)));
        }
    }
}