using S_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace S_DAL.Contexts
{
    public class RequestToConnectContext: DbContext
    {
        public DbSet<RequestToConnect> RequestToConnects { get; set; }

        public RequestToConnectContext(DbContextOptions<RequestToConnectContext> options)
            : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
