using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.EF_ORM;
using Server.Interface;
using FlashSportsLib.Services;
using FlashSportsLib.Models;
using System.Xml.Linq;

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
        private List<ClientChatInfo> _chats;

        public SettingsManager Sm {  get; set; }
        public TextBox SuppChat {  get; set; }
        public ListView Log {  get; set; }

        public ServerRepository()
        {
            _ep = new IPEndPoint(IPAddress.Parse(_ip), _port);
            _bf = new BinaryFormatter();
            _tokenSource = new CancellationTokenSource();
            _db = new FlashSportsDB();
            Sm = new SettingsManager();
            _chats = new List<ClientChatInfo>();
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

        public void ServerStop()
        {
            _tokenSource.Cancel();
            _l.Stop();
            MessageBox.Show($"Server stopped!");
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

                                    List<int> ids = new List<int>();
                                    foreach (var id in _db.Favourites)
                                    {
                                        if(id.UserId == currentUser.Id)
                                            ids.Add(id.SportEventId);
                                    }
                                    response.FavouritesIds = ids;
                                    response.Bets = _db.Bets.Where(b => b.UserId == currentUser.Id).ToList();
                                }
                                UpdateLog("AUTH", $"{currentUser.Id}", "USER", $"{name} ->SUCCESSFUL LOGIN");
                            }
                            else
                            {
                                response.Message = "FAILD";
                                UpdateLog("AUTH", "-1", "USER", $"{name} -> FAILED LOGIN");
                            }

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
                            var response = new ClientResponse
                            {
                                Message = "OK"
                            };
                            _bf.Serialize(netStream, response);
                            UpdateLog("REG", "0", "USER", $"{userReg[0]} -> SUCCESSFUL REG");
                        }
                        break;
                    case "ADDFAVORITE":
                        {
                            var fEvent = (int[])request.Obj;
                            var response = new ClientResponse();
                            Favourite favourite = new Favourite() { Id = 0, UserId = fEvent[0], SportEventId = fEvent[1] };
                            lock (_db)
                            {

                                _db.Favourites.Add(favourite);
                                _db.SaveChanges();
                                // ->
                                response.Message = "OK";
                                List<int> ids = new List<int>();
                                foreach (var id in _db.Favourites)
                                {
                                    if(id.UserId == fEvent[0])
                                        ids.Add(id.SportEventId);
                                }
                                response.FavouritesIds = ids;
                            }
                            _bf.Serialize(netStream, response);

                        }
                        break;
                    case "SUPPORT_LOGIN":
                        {
                            string chat = SuppChat.Text;
                            var response = new SupportResponse() { SuppChat = chat };
                            _bf.Serialize(netStream, response);
                            SuppChat.Invoke(new Action(() => SuppChat.Text = response.SuppChat));
                            UpdateLog("129348", "1", "Support", "Some Act");
                        }
                        break;
                    case "AUTH_SUPP":
                        {
                            var req = (string[])request.Obj;
                            var name = req[0];
                            var pass = req[1];
                            var currentSupp = new Support();

                            lock (_db)
                            {
                                currentSupp = _db.Supports.Where(s => s.SupportName == name && s.Password == pass).FirstOrDefault();
                            }

                            var response = new SupportResponse();
                            if (currentSupp != null)
                            {
                                response.Message = "OK";
                                response.Support = currentSupp;
                                SuppChat.Invoke(new Action(() => { response.SuppChat = SuppChat.Text; }));
                                UpdateLog("AUTH", $"{currentSupp.Id}", "SUPPORT", $"{name} -> SUCCESSFUL LOGIN");
                            }
                            else
                            {
                                response.Message = "FAILED";
                                UpdateLog("AUTH", "-1", "SUPPORT", $"{name} -> FAILED LOGIN");
                            }
                            _bf.Serialize(netStream, response);
                        }
                        break;
                    case "CLIENT_CONTACT_SUP":
                        {
                            var data = (string[])request.Obj;
                            var port = int.Parse(data[0]);
                            var userName = data[1];
                            var ip = data[2];
                            var response = new ClientResponse();
                            lock (_chats)
                            {
                                if (_chats.Where(cci => cci.ClientName == userName).FirstOrDefault() == null)
                                {
                                    _chats.Add(new ClientChatInfo() { Port = port, ClientName = userName, Ip = ip, IsAvailable = true, IssueDate = DateTime.Now });
                                    UpdateLog("CLIENT_CONTACT_SUP", "", "USER", $"{userName} -> SUPPORT REQUEST");
                                    response.Message = "OK";
                                }
                                else
                                {
                                    response.Message = "ALREADY_EXISTS";
                                    UpdateLog("CLIENT_CONTACT_SUP", "", "USER", $"{userName} -> SUPPORT REQUEST DECLINED");
                                }
                            }
                            _bf.Serialize(netStream, response);
                        }
                        break;
                    case "GET_CLIENT_CHATS":
                        {
                            var response = new SupportResponse();
                            lock(_chats)
                            {
                                if (_chats.Count > 0)
                                {
                                    response.Message = "OK";
                                    response.ChatInfo = _chats;
                                }
                            }
                            _bf.Serialize(netStream, response);
                            UpdateLog("GET_CLIENT_CHATS", "", "SUPPORT", $"SUPPORT GET CLIENT CHATS");
                        }
                        break;
                    default:
                        break;
                }
                netStream.Close();
                acceptor.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLog(string key, string userId, string role, string action)
        {
            lock (Log)
            {
                var item = Log.Items.Add(DateTime.Now.ToString("g"));
                item.SubItems.Add(key);
                item.SubItems.Add(userId);
                item.SubItems.Add(role);
                item.SubItems.Add(action);
            }
        }
    }
}
