using Microsoft.EntityFrameworkCore;
using S_DAL.Models;

namespace S_DAL.Contexts
{
    public class PermissionContext : DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Permission> Permissions { get; set; }

        public PermissionContext(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasMany(p => p.Roles)
                .WithMany(r => r.Permissions)
                .UsingEntity<RolePermissionMap>();
        }
    }
}
