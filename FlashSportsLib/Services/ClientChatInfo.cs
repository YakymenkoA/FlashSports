using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    [Serializable]
    public class ClientChatInfo
    {
        public string ClientName { get; set; }
        public DateTime IssueDate { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public bool IsAvailable { get; set; }
    }
}
