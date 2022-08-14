using HeartWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HeartWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<FormModel> FormResults { get; set; } = null!;
    }
}
