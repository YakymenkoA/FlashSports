using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Bet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SportEventId { get; set; }
        public DateTime PlacementDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int CandiesAmount { get; set; }

        // Navigation
        public virtual User User { get; set; }
        public virtual SportEvent SportEvent { get; set; }
    }
}
