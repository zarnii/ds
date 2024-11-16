using Microsoft.EntityFrameworkCore;
using S_DAL.Models;

namespace S_DAL.Contexts
{
    public class RoleContext : DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Role> Roles { get; set; }

        public RoleContext(string connectionString)
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
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<RolePermissionMap>();

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .UsingEntity<UserRoleMap>();

            modelBuilder.Entity<Role>()
                .HasMany(r => r.TextChannels)
                .WithMany(t => t.Roles)
                .UsingEntity<RoleTextchannelMap>();
        }
    }
}
