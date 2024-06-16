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
using FlashSportsLib.Models;

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
                    case "AUTH":
                        {
                            var req = (string[])request.Obj;
                            var name = req[0];
                            var pass = req[1];
                            var currentUser = new User();

                            //multi thread protection, you can't use req[0] and req[1] in LINQ directly
                            lock (_db)
                            {
                                currentUser = _db.Users.Where(u => u.UserName == name && u.Password == pass).FirstOrDefault();
                            }

                            var response = new ClientResponse();

                            if (currentUser != null)
                            {
                                response.Message = "OK";
                                response.User = currentUser;
                                //multi thread protection
                                lock (_db)
                                {
                                    response.CandyAmount = _db.Candies.Where(c => c.UserId == currentUser.Id).First().CandyAmount;
                                    response.SportEvents = _db.SportEvents.ToList();
                                    response.News = _db.News.ToList();
                                    foreach (var id in _db.Favourites.Where(f => f.UserId == currentUser.Id))
                                        response.FavouritesIds.Append(id.SportEventId);
                                }
                            }
                            else
                                response.Message = "FAILD";
                      
                            // ->
                            _bf.Serialize(netStream, response);
                        }
                        break;
                    case "REG":
                        {
                            var userReg = (string[])request.Obj;
                            var user = new User()
                            {
                                Id = 0,
                                UserName = userReg[0],
                                Password = userReg[2],
                                Email = userReg[1],
                                Photo = "",
                                IsBlocked = false,
                               
                            };
                            //multi thread protection
                            lock (_db)
                            {
                                _db.Users.Add(user);
                                _db.SaveChanges();
                                // might swap for trigger in database later
                                _db.Candies.Add(new Candy() { Id = 0, CandyAmount = 0, UserId = _db.Users.Where(u => u.Email == user.Email).First().Id });
                                _db.SaveChanges();
                            }
                            var response = new ClientResponse();
                            response.Message = "OK";
                            _bf.Serialize(netStream, response);
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
