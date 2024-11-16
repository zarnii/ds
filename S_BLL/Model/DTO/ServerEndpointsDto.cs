namespace S_BLL.Model.DTO
{
    public struct ServerEndpointsDto
    {
        public EndpointDto TextChannelEndPoint { get; set; }

        public EndpointDto VoiceChannelEndPoint { get; set; }
    }
}
