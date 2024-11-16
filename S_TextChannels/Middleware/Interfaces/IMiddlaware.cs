using S_TextChannels.Models;

namespace S_TextChannels.Middleware.Interfaces
{
    public interface IMiddlaware
    {
        Task<GttpContext> HandleGttpContext(GttpContext context, IMiddlewareIterator iterator);
    }
}
