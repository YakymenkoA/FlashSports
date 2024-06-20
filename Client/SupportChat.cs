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
using System.Threading;

namespace Client
{
    public partial class SupportChat : Form
    {
        private int _localPort;
        private int _remotePort;
        private IPAddress _remoteAddress;
        private IPEndPoint _remoteEP;
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
            _remoteEP = new IPEndPoint(_remoteAddress, _remotePort);
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
                    udp.Close();
                    if (message == "SUPPORT_DISCONNECTED_FIRST")
                    {
                        message = "Disconnected";
                        SendBtn.Invoke(new Action(() => { SendBtn.Enabled = false; }));
                    }
                    SupChatTB.Invoke(new Action(() =>
                    {
                        SupChatTB.Text += $"[{DateTime.Now:T}] - ({_supportName}):  {message} \r\n";
                    }));
                }
            }
            catch (Exception)
            { }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string message = MessageTB.Text;
            SupChatTB.Text += $"[{DateTime.Now:T}] - ({UserName}):  {message} \r\n";
            DataSender(Encoding.UTF8.GetBytes(message));
            MessageTB.Clear();
        }

        private void DataSender(byte[] data)
        {
            var udpClient = new UdpClient();
            try
            {
                udpClient.Send(data, data.Length, _remoteEP);
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data Sender Error: {ex.Message}");
            }
            finally
            {
                udpClient?.Close();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SendDisconnectRequest()
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

        private void SupportChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            SendDisconnectRequest();
            if (SendBtn.Enabled)
                DataSender(Encoding.UTF8.GetBytes("CLIENT_DISCONNECTED_FIRST"));
        }
    }
}
