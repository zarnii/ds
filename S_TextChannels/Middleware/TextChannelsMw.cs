using S_TextChannels.Middleware.Interfaces;
using S_TextChannels.Models;

namespace S_TextChannels.Middleware
{
    public class TextChannelsMw : IMiddlaware
    {
        public async Task<GttpContext> HandleGttpContext(GttpContext context, IMiddlewareIterator iterator)
        {
            // ...

            if (!iterator.IsDone())
            {
                var next = iterator.GetNext();

                return await next.HandleGttpContext(context, iterator);
            }

            return context;
        }
    }
}
