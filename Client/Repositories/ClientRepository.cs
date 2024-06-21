﻿using Client.Interfaces;
using FlashSportsLib.Models;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Repositories
{
    internal class ClientRepository : IClient
    {
        private int _port;
        private IPAddress _addr;
        private IPEndPoint _ep;
        private TcpClient _client;
        private BinaryFormatter _bf;

        public int newsId;

        public ClientResponse CurrentClientInfo { get; set; }
        public SettingsManager ClientSM { get; set; }

        public ClientRepository()
        {
            ClientSM = new SettingsManager();
            _bf = new BinaryFormatter();
        }

        public void Connect(string ip, int port)
        {
            try
            {
                _addr = IPAddress.Parse(ip);
                _port = port;
                _ep = new IPEndPoint(_addr, _port);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\n> Connection Error:\n  {ex.Message}", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Registration(string username, string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool SendRequest(MyRequest request)
        {
            bool success = false;
            _bf = new BinaryFormatter();
            _client = new TcpClient();
            try
            {
                _client.Connect(_ep);
                NetworkStream ns = _client.GetStream();
                _bf.Serialize(ns, request);
                // ->
                var response = (ClientResponse)_bf.Deserialize(ns);
                if (response.Message == "OK")
                {
                    if (request.Header == "AUTH")
                    {
                        CurrentClientInfo = response;
                        /*MessageBox.Show(
                            "Successfully Authorization!",
                            "Notification",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);*/
                    }
                    else if (request.Header == "REG")
                    {
                        MessageBox.Show(
                            "Successfully Registered!",
                            "Notification",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else if (request.Header == "ADDFAVORITE")
                    {
                        MessageBox.Show(
                            "Event successfully added to Favorites!",
                            "Notification",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CurrentClientInfo.FavouritesIds = response.FavouritesIds;
                    }
                    else if(request.Header == "UPDATEUSER")
                    {
                        MessageBox.Show(
                           "User information successfully update!",
                           "Notification",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                        CurrentClientInfo.User = response.User;
                    }
                    else if (request.Header == "UPDATECANDIES")
                    {
                       /* MessageBox.Show(
                           "User information successfully update!",
                           "Notification",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);*/
                        CurrentClientInfo.CandyAmount = response.CandyAmount;
                    }
                    success = true;
                }
                else
                {
                    if (request.Header == "AUTH")
                    {
                        MessageBox.Show(
                          "Failed Authorization!",
                          "Warning",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning
                          );
                    }
                    else if (request.Header == "REG")
                    {
                        MessageBox.Show(
                          "Failed Registration!",
                          "Warning",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning
                          );
                    }
                    success = false;
                }
                // >
                ns?.Close();
                _client?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }
            finally
            {
                _client?.Close();
            }

            return success;
        }

        public List<SportEvent> FilterEvents(int categoryId)
        {
            return CurrentClientInfo.SportEvents.FindAll(s => s.CategoryId == categoryId);
        }

        public bool AddToFavorite(string title)
        {
            int userId = CurrentClientInfo.User.Id;
            int evId =  CurrentClientInfo.SportEvents.Where(e => e.Title == title).FirstOrDefault().Id;

            int[] ints = new int[2] { userId, evId };
            var request = new MyRequest()
            {
                Header = "ADDFAVORITE",
                Obj = ints
            };
            return SendRequest(request);
        }

        public List<SportEvent> FavoritesEvents()
        {
           List<SportEvent> events = new List<SportEvent>();

            foreach(var e in CurrentClientInfo.FavouritesIds)
            {
                events.Add(CurrentClientInfo.SportEvents.Where(ev => ev.Id == e).FirstOrDefault());
            }
            return events;
        }

        public List<SportEvent> BetsEvents()
        {
            try
            {
                if (CurrentClientInfo == null || CurrentClientInfo.BetsIds == null || CurrentClientInfo.SportEvents == null)
                {
                    MessageBox.Show("You don't have any bets", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<SportEvent>();
                }

                List<SportEvent> events = new List<SportEvent>();

                foreach (var e in CurrentClientInfo.BetsIds)
                {
                    SportEvent sportEvent = CurrentClientInfo.SportEvents.FirstOrDefault(ev => ev.Id == e);
                    if (sportEvent != null)
                    {
                        events.Add(sportEvent);
                    }
                }
                return events;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<SportEvent>();
            }
        }

        public List<FlashSportsLib.Models.News> FillNews()
        {
            return CurrentClientInfo.News;
        }

        public void ContactSupport()
        {
            _client = new TcpClient();
            _ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001);
            _client.Connect(_ep);
            var ns = _client.GetStream();
            var data = new string[] { "9010", CurrentClientInfo.User.UserName, "127.0.0.1", };
            var request = new MyRequest() { Header = "CLIENT_CONTACT_SUP", Obj = data };
            _bf.Serialize(ns, request);
            var response = (ClientResponse)_bf.Deserialize(ns);
            ns?.Close();
            _client?.Close();
            if (response.Message == "OK")
            {
                var chat = new SupportChat(9010) { UserName = CurrentClientInfo.User.UserName };
                chat.Show();
            }
            else
                MessageBox.Show("Your chat is already open!");
        }

        public bool UpdateUser(User u)
        {
            u.Id = CurrentClientInfo.User.Id;
            var request = new MyRequest()
            {
                Header = "UPDATEUSER",
                Obj = (object)u
            };
            return SendRequest(request);
        }

        public bool UpdateCandies(int candies)
        {
            int[] ints = new int[2] { CurrentClientInfo.User.Id, candies };
            var request = new MyRequest()
            {
                Header = "UPDATECANDIES",
                Obj = ints
            };
            return SendRequest(request);
        }

        public void ShowNew(int Id, Label labelTitle, TextBox contentLabel)
        {
            var news = CurrentClientInfo.News.Where(n => n.Id == Id).FirstOrDefault();

            if (news != null)
            {
                labelTitle.Text = news.Title;
                contentLabel.Text = news.Content;
            }
        }
    }
}
