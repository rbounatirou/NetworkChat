using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ServerApp
{
    internal class RemoteServer
    {
        TcpChannel chan = new TcpChannel(8085);
        ChannelServices.RegisterChannel(chan);
    }
}
