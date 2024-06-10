using FlashSportsLib.Interfaces;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Repositories
{
    public class ClientRepository : IClient
    {
        public SettingsManager ClientSM { get; set; }

        public ClientRepository()
        {
            ClientSM = new SettingsManager();
        }
    }
}
