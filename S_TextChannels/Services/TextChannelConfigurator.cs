using S_BLL.Model;
using S_TextChannels.Services.Interfaces;
using System.Net;

namespace S_TextChannels.Services
{
    public class TextChannelConfigurator : ITextChannelConfigurator
    {
        private readonly ServerConfig ServerConfig;

        public TextChannelConfigurator() 
        {
            ServerConfig = new ServerConfig("F:\\C#\\DS\\Server.config");
        }

        public IPEndPoint GetEndPoint()
        {
            var endPoints = ServerConfig.GetServerEndpoints().GetAwaiter().GetResult();

            return new IPEndPoint(
                IPAddress.Parse(endPoints.TextChannelEndPoint.Ip4), 
                endPoints.TextChannelEndPoint.Port);
        }

        public uint GetMaxClientCount()
        {
            return ServerConfig.GetMaxConnectedClientAtOnce();
        }

        public string GetConnectionString()
        {
            return ServerConfig.GetConnectionString();
        }
    }
}
