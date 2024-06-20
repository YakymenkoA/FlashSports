using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Interfaces
{
    internal interface ISupport
    {
        bool AuthSupport();
        void GetClientChatInfos();
        void StartClientChat(string clientName);
    }
}
