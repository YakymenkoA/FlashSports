using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Candy
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CandyAmount { get; set; }

        // Navigation
        public virtual User User { get; set; }
    }
}
