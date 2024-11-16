using S_TextChannels.Middleware.Interfaces;

namespace S_TextChannels.Services
{
    public class MiddlewareIterator : IMiddlewareIterator
    {
        private IServiceProvider _serviceProvider;

        private IList<Type> _middlewares;

        private int _currentIndex;

        public MiddlewareIterator(IServiceProvider serviceProvider, IList<Type> middlewares)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
            ArgumentNullException.ThrowIfNull(middlewares, nameof(middlewares));

            _serviceProvider = serviceProvider;
            _middlewares = middlewares;
            _currentIndex = -1;
        }

        public IMiddlaware? GetNext()
        {
            if (IsDone())
            {
                return null;
            }

            _currentIndex++;
            return (IMiddlaware)_serviceProvider.GetService(_middlewares[_currentIndex]);
        }

        public bool IsDone()
        {
            return _currentIndex == _middlewares.Count - 1;
        }
    }
}
