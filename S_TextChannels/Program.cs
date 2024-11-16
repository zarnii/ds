using Microsoft.EntityFrameworkCore;
using S_BLL.BL;
using S_DAL.Contexts;
using S_TextChannels.Middleware;
using S_TextChannels.Services;

namespace S_TextChannels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appBuilder = new TextChannelsBuilder();
            appBuilder.AddDbContext<UserContext>((optionsBuilder) 
                => optionsBuilder.UseNpgsql(appBuilder.Сongifurator.GetConnectionString()));
            appBuilder.AddMiddleware<AuthenticationMw>();
            appBuilder.AddMiddleware<TextChannelsMw>();
            var app = appBuilder.Build();
            app.Run();
        }
    }
}
