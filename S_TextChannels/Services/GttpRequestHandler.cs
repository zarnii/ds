using GttpGtrpLib.Models;
using GttpGtrpLib.Net;
using S_TextChannels.Models;

namespace S_TextChannels.Services
{
    public class GttpRequestHandler : IGttpRequestHandler
    {
        private IServiceProvider _serviceProvider;

        private IList<Type> _middlewares;

        public GttpRequestHandler(IServiceProvider serviceProvider, IList<Type> middelwares) 
        {
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
            ArgumentNullException.ThrowIfNull(middelwares, nameof(middelwares));

            _serviceProvider = serviceProvider;
            _middlewares = middelwares;
        }

        public async Task<GttpResponse> HandleGttpRequest(GttpRequest request)
        {
            var gttpContext = new GttpContext();
            gttpContext.Request = request;
            var iterator = new MiddlewareIterator(_serviceProvider, _middlewares);
            var gttpResponse = new GttpResponse();

            if (iterator.IsDone())
            {
                gttpResponse.StatusCode = GttpRequestStatusCodes.IternalServerError500;

                return gttpResponse;
            }

            try
            {
                var middleware = iterator.GetNext();
                var result = await middleware.HandleGttpContext(gttpContext, iterator);
            }
            catch (Exception ex) 
            { 
            
            }
            

            // handle result ...
            gttpResponse.StatusCode = GttpRequestStatusCodes.Ok200;

            return gttpResponse;
        }
    }
}
