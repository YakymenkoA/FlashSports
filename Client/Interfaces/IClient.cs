using FlashSportsLib.Models;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    internal interface IClient
    {
        void Connect(string ip, int port);
        void Registration(string username, string email, string password);
        bool SendRequest(MyRequest request);
        List<SportEvent> FilterEvents(int categoryId);
        bool AddToFavorite(string title);
        List<SportEvent> FavoritesEvents();
        List<FlashSportsLib.Models.News> FillNews();
        void ContactSupport();
    }
}
