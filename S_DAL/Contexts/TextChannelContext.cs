using Microsoft.EntityFrameworkCore;
using S_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_DAL.Contexts
{
    public class TextChannelContext: DbContext
    {
        private readonly string ConnectionString;

        public DbSet<TextChannel> TextChannels { get; set; }

        public TextChannelContext(string connectionString)
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
            modelBuilder.Entity<TextChannel>()
                .HasMany(t => t.Messages)
                .WithMany(m => m.TextChannels)
                .UsingEntity<MessageTextchannelMap>();
        }
    }
}
