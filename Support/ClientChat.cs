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
using FlashSportsLib.Models;
using System.Threading;

namespace Support
{
    public partial class ClientChat : Form
    {
        private int _localPort = 9015;
        private int _chatId;
        private List<FlashSportsLib.Models.Message> _messages;
        private IPEndPoint _remoteEP;

        public string SupportName {  get; set; }
        public ClientChatInfo Info { get; set; }
        public Button Btn { get; set; }

        public ClientChat()
        {
            InitializeComponent();
            _messages = new List<FlashSportsLib.Models.Message>();
        }

        private void ClientChat_Load(object sender, EventArgs e)
        {
            ChatGB.Text = $"Chat with {Info.ClientName}";
            Task.Run(() => SendInitialData()).ContinueWith(t => ReceiveMessages());
        }

        private void SendInitialData()
        {
            _remoteEP = new IPEndPoint(IPAddress.Parse(Info.Ip), Info.Port);
            DataSender(Encoding.UTF8.GetBytes($"9015/{SupportName}/127.0.0.1"));
            SendRequest(new MyRequest() { Header = "CREATE_CHAT", Obj = $"{Info.ClientName}~{SupportName}" });
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
                    if (message == "CLIENT_DISCONNECTED_FIRST")
                    {
                        SendBtn.Invoke(new Action(() => { SendBtn.Enabled = false; }));
                        message = "Disconnected";
                    }
                    else
                    {
                        lock (_messages)
                        {
                            _messages.Add(new FlashSportsLib.Models.Message() { ChatId = _chatId, Date = DateTime.Now, MessageText = message });
                        }
                    }
                    ClientChatTB.Invoke(new Action(() =>
                    {
                        ClientChatTB.Text += $"[{DateTime.Now:T}] - ({Info.ClientName}):  {message} \r\n";
                    }));
                }
            }
            catch (Exception)
            { }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var message = MessageTB.Text;
            ClientChatTB.Text += $"[{DateTime.Now:T}] - ({SupportName}):  {message} \r\n";
            MessageTB.Clear();
            DataSender(Encoding.UTF8.GetBytes(message));
            lock (_messages)
            {
                _messages.Add(new FlashSportsLib.Models.Message() { ChatId = _chatId, Date = DateTime.Now, MessageText = message });
            }
        }

        private void SendFinalMessage()
        {
            DataSender(Encoding.UTF8.GetBytes("SUPPORT_DISCONNECTED_FIRST"));
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

        private void SendRequest(MyRequest request)
        {
            var support = new TcpClient();
            var bf = new BinaryFormatter();
            support.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001));
            var ns = support.GetStream();
            bf.Serialize(ns, request);
            if (request.Header == "CREATE_CHAT")
            {
                var response = (SupportResponse)bf.Deserialize(ns);
                _chatId = response.ChatId;
            }
            ns.Close();
            support.Close();
        }

        private void ClientChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            SendRequest(new MyRequest() { Header = "CLIENT_DISCONNECTED", Obj = $"{Info.ClientName}~SUPPORT" });
            SendRequest(new MyRequest() { Header = "SAVE_CHAT_HISTORY", Obj = (object)_messages });
            SendRequest(new MyRequest() { Header = "SEND_SUPPORT_MAIL", Obj = $"{_chatId}~{Info.ClientName}" });
            if (SendBtn.Enabled)
                SendFinalMessage();
        }
    }
}
