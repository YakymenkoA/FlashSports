using Client.Interfaces;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Repositories
{
    internal class ClientRepository : IClient
    {
        private int _port;
        private IPAddress _addr;
        private IPEndPoint _ep;

        public SettingsManager ClientSM { get; set; }

        public ClientRepository()
        {
            ClientSM = new SettingsManager();
        }

        public void Authorization(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Connect(string ip, string port)
        {
            try
            {
                _addr = IPAddress.Parse(ip);
                _port = int.Parse(port);
                _ep = new IPEndPoint(_addr, _port);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\n> Connection Error:\n  {ex.Message}", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Registration(string username, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
