using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool IsBlocked { get; set; }

        // Navigation
        public virtual List<Bet> Bets { get; set; }
        public virtual List<Candy> Candies { get; set; }
        public virtual List<Favourite> Favourites { get; set; }
        public virtual List<Chat> Chats { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
