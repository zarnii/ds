using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S_BLL.Model;
using S_BLL.Model.DTO;

namespace S_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServerEndpointsController : Controller
    {
        private readonly ServerConfig ServerConfig;

        public ServerEndpointsController(ServerConfig serverConfig)
        {
            ServerConfig = serverConfig;
        }

        [HttpGet]
        public async Task<ServerEndpointsDto> Get()
        {
            return await ServerConfig.GetServerEndpoints();
        }
    }
}
