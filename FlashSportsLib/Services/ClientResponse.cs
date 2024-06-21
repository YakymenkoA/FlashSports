using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    [Serializable]
    public class ClientResponse
    {
        public string Message { get; set; }
        public List<SportEvent> SportEvents { get; set; }
        public List<News> News { get; set; }
        public int CandyAmount { get; set; }
        public List<int> FavouritesIds { get; set; }
        public List<int> BetsIds { get; set; }
        public User User { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
