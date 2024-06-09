using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class SportEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime IssueDate { get; set; }
        public int CategoryId { get; set; }

        // Navigation
        public virtual Category Category { get; set; }
        public virtual List<Bet> Bets { get; set; }
        public virtual List<Favourite> Favourites { get; set; }
    }
}
