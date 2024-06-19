using FlashSportsLib.Services;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.Serialization.Formatters.Binary;

namespace Support
{
    public partial class ClientChat : Form
    {
        private int _localPort = 9015;

        public string SupportName {  get; set; }
        public ClientChatInfo Info { get; set; }
        public Button Btn { get; set; }

        public ClientChat()
        {
            InitializeComponent();
        }

        private void ClientChat_Load(object sender, EventArgs e)
        {
            ChatGB.Text = $"Chat with {Info.ClientName}";
            Task.Run(() => SendInitialData()).ContinueWith(t => ReceiveMessages());
        }

        private void SendInitialData()
        {
            var udpClient = new UdpClient();
            var ip = IPAddress.Parse(Info.Ip);
            var remoteEP = new IPEndPoint(ip, Info.Port);

            try
            {
                byte[] data = Encoding.UTF8.GetBytes($"9015/{SupportName}/127.0.0.1");
                udpClient.Send(data, data.Length, remoteEP);
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send Error: {ex.Message}");
            }
            finally
            {
                udpClient?.Close();
            }
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
                    ClientChatTB.Invoke(new Action(() =>
                    {
                        ClientChatTB.Text += $"[{DateTime.Now:T}] - ({Info.ClientName}):  {message} \r\n";
                    }));
                    udp.Close();
                }
            }
            catch (Exception)
            { }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var udpClient = new UdpClient();
            var ip = IPAddress.Parse(Info.Ip);
            var remoteEP = new IPEndPoint(ip, Info.Port);

            try
            {
                var message = string.Empty;
                ClientChatTB.Invoke(new Action(() =>
                {
                    message = MessageTB.Text;
                    ClientChatTB.Text += $"[{DateTime.Now:T}] - ({SupportName}):  {message} \r\n";
                    MessageTB.Clear();
                }));
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, remoteEP);
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send Error: {ex.Message}");
            }
            finally
            {
                udpClient?.Close();
            }
        }

        private void SendRequest(MyRequest request)
        {
            var support = new TcpClient();
            var bf = new BinaryFormatter();
            support.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001));
            var ns = support.GetStream();
            bf.Serialize(ns, request);
            ns.Close();
            support.Close();
        }

        private void ClientChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            SendRequest(new MyRequest() { Header = "CLIENT_DISCONNECTED", Obj = $"{Info.ClientName}~SUPPORT" });
            SendRequest(new MyRequest() { Header = "SAVE_CHAT_HISTORY", Obj = ClientChatTB.Text });
        }
    }
}
