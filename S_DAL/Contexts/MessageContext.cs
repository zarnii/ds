using Microsoft.EntityFrameworkCore;
using S_DAL.Models;

namespace S_DAL.Contexts
{
    public class MessageContext: DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Message> Messages { get; set; }

        public MessageContext(string connectionString)
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
            modelBuilder.Entity<Message>()
                .HasMany(m => m.TextChannels)
                .WithMany(t => t.Messages)
                .UsingEntity<MessageTextchannelMap>();
             
        }
    }
}
