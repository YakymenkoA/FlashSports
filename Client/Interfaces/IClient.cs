using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    internal interface IClient
    {
        void Connect(string ip, int port);

        void Registration(string username, string email, string password);

    }
}
