using GttpGtrpLib.Net;
using Microsoft.Extensions.DependencyInjection;
using S_TextChannels.Middleware.Interfaces;
using S_TextChannels.Services.Interfaces;

namespace S_TextChannels.Services
{
    public class TextChannelsBuilder
    {
        public ITextChannelConfigurator Сongifurator { get; }

        private IServiceCollection _serviceCollection;

        private List<Type> _middlewares;

        public TextChannelsBuilder() 
        {
            Сongifurator = new TextChannelConfigurator();
            _serviceCollection= new ServiceCollection();
            _middlewares = new List<Type>();
        }

        public void AddMiddleware<TMiddleware>()
            where TMiddleware : IMiddlaware
        {
            AddMiddleware(typeof(TMiddleware));
        }

        public void AddMiddleware(IMiddlaware middleware)
        {
            AddMiddleware(middleware.GetType());
            
        }

        public void AddService<TService>()
        {
            _serviceCollection.AddScoped(typeof(TService));
        }

        public void AddDbContext<TContext>(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TContext: Microsoft.EntityFrameworkCore.DbContext
        {
            _serviceCollection.AddDbContext<TContext>(serviceLifetime);
        }

        public void AddDbContext<TContext>(
            Action<Microsoft.EntityFrameworkCore.DbContextOptionsBuilder> optionsAction,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TContext : Microsoft.EntityFrameworkCore.DbContext
        {
            _serviceCollection.AddDbContext<TContext>(optionsAction, serviceLifetime);
        }

        public void AddDbContext<TContext>(
            Action<IServiceProvider, Microsoft.EntityFrameworkCore.DbContextOptionsBuilder> optionsAction,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
            where TContext : Microsoft.EntityFrameworkCore.DbContext
        {
            _serviceCollection.AddDbContext<TContext>(optionsAction, serviceLifetime);
        }

        public TextChannelApp Build()
        {
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            var gttpRequestHandler = new GttpRequestHandler(serviceProvider, _middlewares);
            var gttpServer = new GttpServer(
                Сongifurator.GetEndPoint(),
                Сongifurator.GetMaxClientCount(),
                gttpRequestHandler);

            return new TextChannelApp(gttpServer, serviceProvider, _middlewares);
        }

        private void AddMiddleware(Type middleware)
        {
            _middlewares.Add(middleware);
            _serviceCollection.AddScoped(middleware);
        }
    }
}
