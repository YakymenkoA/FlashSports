using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using FlashSportsLib.Models;

namespace Support
{
    public partial class SupportMain : Form
    {
        private Socket _socket;
        private bool _isConnected = false;

        public SupportMain()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                try
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                    _isConnected = false;
                    PortTB.Enabled = true;
                    ConnectBtn.Text = "Connect";
                    ClearBtn.Enabled = false;
                    SendBtn.Enabled = false;
                    MessageTB.Enabled = false;
                    StartChatBtn.Enabled = false;
                    PendingChatLV.Enabled = false;
                    PortTB.Clear();                    
                    MessageBox.Show("Disconnected successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error - {ex}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    IPAddress ip = IPAddress.Parse("127.0.0.1");
                    int port = int.Parse(PortTB.Text);

                    if (port < 6000 || port > 65535)
                    {
                        MessageBox.Show("Please enter a valid port number (between 6000 and 65535).", "Invalid Port",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    IPEndPoint ep = new IPEndPoint(ip, port);

                    _socket = new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp
                    );

                    _socket.Connect(ep);
                    _isConnected = true;
                    PortTB.Enabled = false;
                    ConnectBtn.Text = "Disconnect";
                    ClearBtn.Enabled = true;
                    SendBtn.Enabled = true;
                    MessageTB.Enabled = true;
                    StartChatBtn.Enabled = true;
                    PendingChatLV.Enabled = true;
                    MessageBox.Show("Connected successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error - {ex}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SupportMain_Load(object sender, EventArgs e)
        {
            var auth = new Login();
            if (auth.ShowDialog() == DialogResult.OK)
            {
                
            }
            else
                this.Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }
    }
}
