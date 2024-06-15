using Client.Interfaces;
using FlashSportsLib.Models;
using FlashSportsLib.Services;
using FlashSportsLIb2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
        private TcpClient _client;
        private BinaryFormatter _bf;

        public ClientResponse CurrentClientInfo { get; set; }
        public SettingsManager ClientSM { get; set; }

        public ClientRepository()
        {
            ClientSM = new SettingsManager();
        }

        public void Connect(string ip, int port)
        {
            try
            {
                _addr = IPAddress.Parse(ip);
                _port = port;
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

        public bool SendRequest(MyRequest request)
        {
            _bf = new BinaryFormatter();
            bool success = false;
            _client = new TcpClient();
            _client.Connect(_ep);
            NetworkStream ns = _client.GetStream();
            _bf.Serialize(ns, request);
            // ->
            var response = (ClientResponse) _bf.Deserialize(ns);
            if(response.Message == "OK")
            {
                if(request.Header == "AUTH")
                {
                    CurrentClientInfo = response;
                    MessageBox.Show(
                  "Sucsessfuly Authorization!",
                  "Notification",
                  MessageBoxButtons.OK,
                   MessageBoxIcon.Information
                  );
                }
                else if(request.Header == "REG")
                {
                    MessageBox.Show(
                 "Sucsessfuly Registered!",
                 "Notification",
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Information
                 );
                }
                success = true;
            }
            else
            {
                if(request.Header == "AUTH")
                {
                    MessageBox.Show(
                      "Faild Authorization!",
                      "Warrning",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                      );
                }      
                else if (request.Header == "REG")
                {
                    MessageBox.Show(
                      "Faild Registration!",
                      "Warrning",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                      );
                }
                    success = false;
            }
            // >
            ns?.Close();
            _client?.Close();
            return success;
        }
    }
}
