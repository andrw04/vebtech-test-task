using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entities;

namespace TestTask.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set;  }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
