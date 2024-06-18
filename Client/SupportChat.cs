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

namespace Client
{
    public partial class SupportChat : Form
    {
        private int _localPort;
        private int _remotePort;
        private IPAddress _remoteAddress;
        private string _supportName = "supName";

        public SupportChat(int localPort)
        {
            InitializeComponent();
            SendBtn.Enabled = false;
            _localPort = localPort;
        }

        private void SupportChat_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Wait for the support to connect!");
            ReceiveInitialData();
        }

        private void ReceiveInitialData()
        {
            var udp = new UdpClient(_localPort);
            IPEndPoint ep = null;
            byte[] data = udp.Receive(ref ep);
            var dataString = Encoding.UTF8.GetString(data);
            var split = dataString.Split('~');
            _remotePort = int.Parse(split[0]);
            _supportName = split[1];
            _remoteAddress = IPAddress.Parse(split[2]);
            SendBtn.Enabled = true;
            Task.Run(() => ReceiveMessages());
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
                        SupChatTB.Text += $"{DateTime.Now:t} {_supportName}: {message} \r\n";
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
                byte[] data = Encoding.UTF8.GetBytes(MessageTB.Text);
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
    }
}
