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
        private int _port;
        private IPEndPoint _ep;
        private BinaryFormatter _bf;
        private TcpClient _support;

        public TextBox GeneralChat {  get; set; }
        public ListView ClientChats { get; set; }
        public SupportResponse CurrentSupportInfo { get; set; }
        public SettingsManager SupportSM { get; set; }


        public SupportRepository()
        {
            _port = 9001;
            _ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _port);
            _bf = new BinaryFormatter();
            SupportSM = new SettingsManager();
        }

        public bool AuthSupport()
        {
            var login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    _support = new TcpClient();
                    _support.Connect(_ep);
                    var ns = _support.GetStream();
                    var data = new string[] { login.LoginDto, login.PasswordDto };
                    var request = new MyRequest() { Header = "AUTH_SUPP", Obj = data };
                    _bf.Serialize(ns, request);
                    var response = (SupportResponse)_bf.Deserialize(ns);
                    ns?.Close();
                    if (response.Message == "OK")
                    {
                        CurrentSupportInfo = response;
                        GeneralChat.Text = CurrentSupportInfo.SuppChat;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed Authorization!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Authorization Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    _support?.Close();
                }
            }
            return false;
        }

        public void GetClientChatInfos()
        {
            try
            {
                _support = new TcpClient();
                _support.Connect(_ep);
                var ns = _support.GetStream();
                var request = new MyRequest() { Header = "GET_CLIENT_CHATS" };
                _bf.Serialize(ns, request);
                var response = (SupportResponse)_bf.Deserialize(ns);
                if (response.Message == "OK")
                {
                    CurrentSupportInfo.ChatInfo = response.ChatInfo;

                    ClientChats.Invoke(new Action(() =>
                    {
                        ClientChats.Items.Clear();
                        foreach (var chat in CurrentSupportInfo.ChatInfo)
                        {
                            var item = ClientChats.Items.Add($"{chat.IssueDate:t}");
                            item.SubItems.Add($"{chat.ClientName}");
                            if (chat.IsAvailable)
                                item.SubItems.Add("Available");
                            else
                                item.SubItems.Add("Unavailable");
                        }
                    }));
                }
                else
                {
                    ClientChats.Invoke(new Action(() =>
                    {
                        ClientChats.Items.Clear();
                    }));
                }
                ns?.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Get Client Chat Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _support?.Close();
            }
        }

        public void StartClientChat(string clientName)
        {
            try
            {
                _support = new TcpClient();
                _support.Connect(_ep);
                var ns = _support.GetStream();
                var request = new MyRequest() { Header = "START_CLIENT_CHAT", Obj = clientName };
                _bf.Serialize(ns, request);
                var response = (SupportResponse)_bf.Deserialize(ns);
                ns?.Close();
                _support?.Close();
                if (response.Message == "OK")
                {
                    var clientChat = new ClientChat()
                    {
                        Info = CurrentSupportInfo.ChatInfo.Where(i => i.ClientName == clientName).First(),
                        SupportName = CurrentSupportInfo.Support.SupportName
                    };
                    clientChat.Show();
                }
                else
                {
                    MessageBox.Show("Chat is Busy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Start Chat Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _support?.Close();
            }
        }

        public void GetGeneralChat()
        {
            try
            {
                _support = new TcpClient();
                _support.Connect(_ep);
                var ns = _support.GetStream();
                var request = new MyRequest() { Header = "GET_SUPPORT_CHATS" };
                _bf.Serialize(ns, request);
                var response = (SupportResponse)_bf.Deserialize(ns);
                if (response.Message == "OK")
                {
                    GeneralChat.Text = response.SuppChat.ToString();   
                }
                else
                {
                    GeneralChat.Clear();
                }
                ns?.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Get Support Chat Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _support?.Close();
            }
        }
        public void SendMess(string mess)
        {
            GeneralChat.Text += $"\r\n{mess}";
            try
            {
                _support = new TcpClient();
                _support.Connect(_ep);
                var ns = _support.GetStream();
                var request = new MyRequest() { Header = "ADD_SUPPORT_MESS" };
                request.Obj = mess;
                _bf.Serialize(ns, request);
                ns?.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Get Support Chat Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _support?.Close();
            }
        }
    }
}
