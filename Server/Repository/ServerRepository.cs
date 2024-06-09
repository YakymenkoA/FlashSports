using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlashSportsLIb2.Services;
using System.Windows.Forms;
using Server.EF_ORM;
using Server.Interface;
using FlashSportsLib.Services;

namespace Server.Repositories
{
    internal class ServerRepository : IServer
    {
        private readonly int _port = 9001;
        private readonly string _ip = "127.0.0.1";
        private IPEndPoint _ep;
        private BinaryFormatter _bf;
        private CancellationTokenSource _tokenSource;
        private TcpListener _l;
        private Task _serverThread;
        private FlashSportsDB _db;
        public SettingsManager Sm {  get; set; }

        public ServerRepository()
        {
            _ep = new IPEndPoint(IPAddress.Parse(_ip), _port);
            _bf = new BinaryFormatter();
            _tokenSource = new CancellationTokenSource();
            _db = new FlashSportsDB();
            Sm = new SettingsManager();
        }

        public void ServerStart()
        {
            try
            {
                _l = new TcpListener(_ep);
                _l.Start(100);
                _serverThread = new Task(ServerQueueThread, _tokenSource.Token);
                _serverThread.Start();
                MessageBox.Show($"Server started!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Server Start Error: {ex.Message}");
            }
        }

        private void ServerQueueThread()
        {
            try
            {
                bool stop = false;
                while (!stop)
                {
                    var acceptor = _l.AcceptTcpClient();
                    Task.Run(() => ServerHandlerThread(acceptor));
                    _tokenSource.Token.Register(() => { stop = true; });
                }
            }
            catch (Exception)
            { }
        }

        private void ServerHandlerThread(TcpClient acceptor)
        {
            try
            {
                var netStream = acceptor.GetStream();
                var request = (MyRequest)_bf.Deserialize(netStream);

                switch (request.Header)
                {
                    case "ADMIN_STOP_SERVER":
                        {
                            ServerStop();
                        }
                        break;
                    default:
                        break;
                }
                netStream.Close();
                acceptor.Close();
            }
            catch (Exception)
            { }
        }

        public void ServerStop()
        {
            _tokenSource.Cancel();
            _l.Stop();
            MessageBox.Show($"Server stopped!");
        }

    }
}
