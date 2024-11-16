using GttpGtrpLib.Models;

namespace GttpGtrpLib.Net
{
    public interface IGttpRequestHandler
    {
        Task<GttpResponse>  HandleGttpRequest(GttpRequest request);
    }
}
