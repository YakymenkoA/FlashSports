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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                            UpdateLog("ADDFAVORITE", $"{fEvent[0]}", "USER", $"EVENT -> SUCCESSFUL ADDED");

                        }
                        break;
                    case "UPDATEUSER":
                        {
                            var u = (User)request.Obj;
                            var response = new ClientResponse();
                            lock (_db)
                            {
                                var user = _db.Users.Where(us => us.Id == u.Id).First();
                                user.UserName = u.UserName;
                                user.Password = u.Password;
                                user.Email = u.Email;
                                user.Photo = u.Photo;
                                _db.SaveChanges();
                            }
                            response.Message = "OK";
                            response.User = u;
                            _bf.Serialize(netStream, response);
                            UpdateLog("UPDATEUSER", $"{u.Id}", "USER", $"{u.UserName} -> SUCCESSFUL UDATE");
                        }
                        break;
                    case "UPDATECANDIES":
                        {
                            var reques = (int[])request.Obj;
                            int id = reques[0];
                            int amount = reques[1];
                            var response = new ClientResponse();
                            lock (_db)
                            {
                                _db.Candies.Where(c => c.UserId == id).First().CandyAmount = amount;
                                _db.SaveChanges();  
                            }
                            response.Message = "OK";
                            response.CandyAmount = amount;
                            _bf.Serialize(netStream, response);
                            UpdateLog("UPDATECANDIES", $"{reques[0]}", "USER", $"CandyAmount -> SUCCESSFUL UPDATED");
                        }
                        break;
                    case "GET_SUPPORT_CHATS":
                        {
                            //......
                            var response = new SupportResponse();
                            response.Message = "OK";
                            SuppChat.Invoke(new Action(() =>
                            {
                                response.SuppChat = SuppChat.Text;
                            }));
                            _bf.Serialize(netStream, response);
                        }
                        break;
                    case "ADD_SUPPORT_MESS":
                        {
                            var req = request.Obj.ToString();
                            
                            SuppChat.Text += $"\r\n> {req}";
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
                                else
                                    response.Message = "FAILED";
                            }
                            _bf.Serialize(netStream, response);
                            //UpdateLog("GET_CLIENT_CHATS", "", "SUPPORT", $"SUPPORT GET CLIENT CHATS");
                        }
                        break;
                    case "START_CLIENT_CHAT":
                        {
                            var name = (string)request.Obj;
                            var response = new SupportResponse();
                            var info = new ClientChatInfo();

                            lock (_chats)
                            {
                                info = _chats.Where(cci => cci.ClientName == name).First();
                            }

                            if (info != null)
                            {
                                if (info.IsAvailable)
                                {
                                    response.Message = "OK";
                                    info.IsAvailable = false;
                                    UpdateLog("START_CLIENT_CHAT", "", "SUPPORT", $"STARTING CHAT");
                                }
                                else
                                {
                                    response.Message = "CHAT_IS_BUSY";
                                    UpdateLog("START_CLIENT_CHAT", "", "SUPPORT", $"CHAT IS BUSY, DECLINED");
                                }
                            }
                            else
                            {
                                response.Message = "CHAT IS CLOSED";
                                UpdateLog("START_CLIENT_CHAT", "", "SUPPORT", $"CHAT IS CLOSED, DECLINED");
                            }

                            _bf.Serialize(netStream, response);
                        }
                        break;
                    case "CLIENT_DISCONNECTED":
                        {
                            var data = (string)request.Obj;
                            var parts = data.Split('~');
                            var name = parts[0];
                            var sender = parts[1];
                            lock (_chats)
                            {
                                var chat = _chats.Where(c => c.ClientName == name).FirstOrDefault();
                                if (chat != null)
                                {
                                    _chats.Remove(chat);
                                    UpdateLog("CLIENT_DISCONNECTED", "", $"{sender}", $"CHAT INFO REMOVE");
                                }
                                else
                                {
                                    UpdateLog("CLIENT_DISCONNECTED", "", $"{sender}", $"NO ACTION");
                                }
                            }
                        }
                        break;
                    case "CREATE_CHAT":
                        {
                            var data = ((string)request.Obj).Split('~');
                            var userName = data[0];
                            var supName = data[1];
                            var chatId = -1;

                            lock (_db)
                            {
                                var chat = new Chat()
                                {
                                    Date = DateTime.Now,
                                    SupportId = _db.Supports.Where(s => s.SupportName == supName).First().Id,
                                    UserId = _db.Users.Where(u => u.UserName == userName).First().Id
                                };
                                _db.Chats.Add(chat);
                                _db.SaveChanges();
                                chatId = chat.Id;
                            }

                            var response = new SupportResponse() { ChatId = chatId };
                            _bf.Serialize(netStream, response);
                            UpdateLog("CREATE_CHAT", "", "SUPPORT", $"CHAT CREATED");
                        }
                        break;
                    case "SAVE_CHAT_HISTORY":
                        {
                            var messages = (List<FlashSportsLib.Models.Message>)request.Obj;
                            lock (_db)
                            {
                                _db.Messages.AddRange(messages);
                                _db.SaveChanges();
                            }
                            UpdateLog("SAVE_CHAT_HISTORY", "", "SUPPORT", $"CHAT HISTORY SAVED");
                        }
                        break;
                    case "SEND_SUPPORT_MAIL":
                        {
                            var data = ((string)request.Obj).Split('~');
                            var chatId = int.Parse(data[0]);
                            var clientName = data[1];
                            var chatLog = string.Empty;
                            var clientEmail = string.Empty;

                            lock(_db)
                            {
                                var messages = _db.Messages.Where(m => m.ChatId == chatId).ToList();
                                foreach (var m in messages)
                                    chatLog += $"{m.Date:T}:  {m.MessageText}\n";
                                clientEmail = _db.Users.Where(u => u.UserName == clientName).First().Email;
                            }

                            var mm = new MailManager();
                            mm.SendMail(clientEmail, chatLog);
                            UpdateLog("SEND_SUPPORT_MAIL", "", "SUPPORT", $"SENDING MAIL");
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
                Log.Invoke(new Action(() =>
                {
                    var item = Log.Items.Add(DateTime.Now.ToString("g"));
                    item.SubItems.Add(key);
                    item.SubItems.Add(userId);
                    item.SubItems.Add(role);
                    item.SubItems.Add(action);
                }));
                          
            }
        }
    }
}
