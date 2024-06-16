using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLIb2.Services
{
    [Serializable]
    public class ClientResponse
    {
        public string Message { get; set; }
        public List<SportEvent> SportEvents { get; set; }
        public List<News> News { get; set; }
        public int CandyAmount { get; set; }
        public int[] FavouritesIds { get; set; }
        public User User { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
