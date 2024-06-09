using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interface
{
    internal interface IServer
    {
        void ServerStart();
        void ServerStop();
    }
}
