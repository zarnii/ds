using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace S_TextChannels.Services.Interfaces
{
    public interface ITextChannelConfigurator
    {
        IPEndPoint GetEndPoint();

        uint GetMaxClientCount();

        string GetConnectionString();
    }
}
