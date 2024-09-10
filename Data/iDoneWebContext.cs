using Microsoft.EntityFrameworkCore;
using iDoneWeb.Models;
namespace iDoneWeb.Data
{
    public class iDoneWebContext : DbContext
    {
        public iDoneWebContext(DbContextOptions<iDoneWebContext> options) : base(options)
        {
        }
        public DbSet<UserTask> UserTasks { get; set; } // Table Name
        public DbSet<User> Users { get; set; } // Table Name

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
