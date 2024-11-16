using GttpGtrpLib.Models;
using GttpGtrpLib.Utils;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GttpGtrpLib.Net
{
    public class GttpServer: IGttpServer
    {
        private const byte GttpHeaderSize = 4;

        private const int DefaultSizeOfBufferToRead = 512;

        private readonly Socket ServerSocket;

        private readonly int MaxClientCount;

        private readonly GttpRequestParser GttpParser;

        private readonly List<Socket> Clients;

        public IGttpRequestHandler RequestHandler { get; }

        private bool _isStarted = false;

        public GttpServer(
            IPEndPoint localEP, 
            uint maxClientsCount,
            IGttpRequestHandler requestHandler)
        {
            ArgumentNullException.ThrowIfNull(localEP);
            ArgumentNullException.ThrowIfNull(requestHandler);

            ServerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            MaxClientCount = (int)maxClientsCount;
            Clients = new List<Socket>(MaxClientCount);
            GttpParser = new GttpRequestParser();
            RequestHandler = requestHandler;

            ServerSocket.Bind(localEP);
        }

        ~GttpServer()
        {
            Stop();
        }

        public async Task Run()
        {
            ServerSocket.Listen(MaxClientCount);
            _isStarted = true;

            while (_isStarted)
            {
                var client = await ServerSocket.AcceptAsync();
                Clients.Add(client);
                HandleClient(client);
            }
        }

        public void Stop()
        {
            _isStarted = false;

            foreach (var client in Clients)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
            }

            ServerSocket.Shutdown(SocketShutdown.Both);
        }

        private async Task HandleClient(Socket client)
        {
            var buffer = new byte[GttpHeaderSize];

            while (_isStarted)
            {
                await client.ReceiveAsync(buffer);
                var payloadSize = BitConverter.ToInt32(buffer);
                var stringRequest = await ReadGttpRequest(payloadSize, client);
                var gttpRequest = GttpParser.Parse(stringRequest);
                var response = await RequestHandler.HandleGttpRequest(gttpRequest);
            }
        }

        private async Task<string> ReadGttpRequest(int payloadSize, Socket socketToRead)
        {
            try
            {
                var bytesToRead = payloadSize;
                var byteRequest = new List<byte>(payloadSize);
                var buffer = new byte[DefaultSizeOfBufferToRead];

                while (bytesToRead > 0)
                {
                    var readedBytes = await socketToRead.ReceiveAsync(buffer);

                    var zeroByteIndex = Array.IndexOf<byte>(buffer, 0);
                    var lengthToCopy = zeroByteIndex == -1
                        ? buffer.Length
                        : buffer.Length - (buffer.Length - zeroByteIndex);

                    byteRequest.AddRange(buffer.Take(lengthToCopy));
                    bytesToRead -= readedBytes;
                    Array.Clear(buffer);
                }

                return Encoding.UTF8.GetString(byteRequest.ToArray());
            }
            catch (Exception ex) // temp.
            {
                throw ex;
            }
        }
    }
}
