using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashSportsLib.Services;
using Support.Interfaces;

namespace Support.Repositories
{
    internal class SupportRepository : ISupport
    {
        private IPAddress _ip;
        private int _port;
        private IPEndPoint _ep;
        private BinaryFormatter _bf;
        private TcpClient _support;
        public TextBox GeneralChat {  get; set; }

        public SupportResponse CurrentSupportInfo { get; set; }

        public SupportRepository()
        {
            _port = 9001;
            _ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _port);
        }

        public void ConnectSupp()
        {
            _bf = new BinaryFormatter();
            _support = new TcpClient();
            //_support.Connect(_ep);
            NetworkStream ns = _support.GetStream();

            _bf.Serialize(ns, "SUPPORT_LOGIN");
            var response = (SupportResponse)_bf.Deserialize(ns);
            //GeneralChat.Text += "Hello, yo";
            GeneralChat.Invoke(new Action( () => GeneralChat.Text = response.SuppChat));

            ns?.Close();
            _support?.Close();
        }

        public void Connect(string ip, int port)
        {
            try
            {
                _ip = IPAddress.Parse(ip);
                _port = port;
                _ep = new IPEndPoint(_ip, _port);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\n> Connection Error:\n  {ex.Message}", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SendRequest(MyRequest request)
        {
            _bf = new BinaryFormatter();
            bool success;
            _support = new TcpClient();
            _support.Connect(_ep);
            NetworkStream ns = _support.GetStream();
            _bf.Serialize(ns, request);
            // ->
            var response = (SupportResponse) _bf.Deserialize(ns);
            if (response.Message == "OK")
            {
                CurrentSupportInfo = response;
                MessageBox.Show(
                "Successfully Authorization!",
                "Notification",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
                success = true;
            }
            else
            {

                MessageBox.Show(
                    "Failed Authorization!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                success = false;
            }
            ns?.Close();
            _support?.Close();
            return success;
        }
    }
}
