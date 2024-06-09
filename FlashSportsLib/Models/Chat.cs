using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Chat
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SupportId { get; set; }
        public int UserId { get; set; }


        // Navigation
        virtual public User User { get; set; }
        virtual public Support Support { get; set; }
        public virtual List<Message> Messages { get; set; }

    }
}
