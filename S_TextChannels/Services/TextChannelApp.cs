using GttpGtrpLib.Net;
using S_TextChannels.Middleware.Interfaces;

namespace S_TextChannels.Services
{
    public class TextChannelApp
    {
        private readonly IGttpServer Server;

        private IServiceProvider _serviceProvider;

        private IList<Type> _middlewares;

        public TextChannelApp(
            IGttpServer server, 
            IServiceProvider serviceProvider, 
            IList<Type> middlewares)
        {
            ArgumentNullException.ThrowIfNull(server, nameof(server));
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
            ArgumentNullException.ThrowIfNull(middlewares, nameof(middlewares));

            Server = server;
            _serviceProvider = serviceProvider;
            _middlewares = middlewares;
        }

        public void Run()
        {
            Server.Run().GetAwaiter().GetResult();
        }
    }
}
