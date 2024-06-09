using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
        public int ChatId { get; set; }

        // Navigation
        public virtual Chat Chat { get; set; }

    }
}
