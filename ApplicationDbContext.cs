using Microsoft.EntityFrameworkCore;
using RBMS.Entities;

namespace RBMS
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAccess> UserAccesses { get; set; }

        public DbSet<RBMS.Entities.UserRole> UserRole { get; set; }
    }
}
