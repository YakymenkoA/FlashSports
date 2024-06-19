using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashSportsLib.Models;
using FlashSportsLib.Services;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class SupportChat : Form
    {
        private int _localPort;
        private int _remotePort;
        private IPAddress _remoteAddress;
        private string _supportName = "supName";

        public string UserName {  get; set; }

        public SupportChat(int localPort)
        {
            InitializeComponent();
            SendBtn.Enabled = false;
            _localPort = localPort;
        }
        private void SupportChat_Load(object sender, EventArgs e)
        {
            Task.Run(() => ReceiveInitialData()).ContinueWith(t => ReceiveMessages());
        }

        private void ReceiveInitialData()
        {
            var udp = new UdpClient(_localPort);
            IPEndPoint ep = null;
            byte[] data = udp.Receive(ref ep);
            var dataString = Encoding.UTF8.GetString(data);
            var split = dataString.Split('/');
            _remotePort = int.Parse(split[0]);
            _supportName = split[1];
            _remoteAddress = IPAddress.Parse(split[2]);
            SupChatTB.Invoke(new Action(() =>
            {
                SupChatTB.Text += $"[{DateTime.Now:T}] - ({_supportName}): Connected! \r\n";
            }));
            SendBtn.Invoke(new Action(() => { SendBtn.Enabled = true; }));
            ChatGB.Invoke(new Action(() =>
            {
                ChatGB.Text = $"Chat with {_supportName}";
            }));
            udp.Close();
        }

        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    var udp = new UdpClient(_localPort);
                    IPEndPoint ep = null;
                    byte[] data = udp.Receive(ref ep);
                    var message = Encoding.UTF8.GetString(data);
                    SupChatTB.Invoke(new Action(() =>
                    {
                        SupChatTB.Text += $"[{DateTime.Now:T}] - ({_supportName}):  {message} \r\n";
                    }));
                    udp.Close();
                }
            }
            catch (Exception)
            { }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var udp = new UdpClient();
            var ep = new IPEndPoint(_remoteAddress, _remotePort);

            try
            {
                string message = string.Empty;
                MessageTB.Invoke(new Action(() =>
                {
                    message = MessageTB.Text;
                    SupChatTB.Text += $"[{DateTime.Now:T}] - ({UserName}):  {message} \r\n";
                    MessageTB.Clear();
                }));
                byte[] data = Encoding.UTF8.GetBytes(message);
                udp.Send(data, data.Length, ep);
                udp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send Error: {ex.Message}");
            }
            finally
            {
                udp?.Close();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SupportChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            var support = new TcpClient();
            var bf = new BinaryFormatter();
            support.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001));
            var ns = support.GetStream();
            var request = new MyRequest() { Header = "CLIENT_DISCONNECTED", Obj = $"{UserName}~USER" };
            bf.Serialize(ns, request);
            ns.Close();
            support.Close();
        }
    }
}
