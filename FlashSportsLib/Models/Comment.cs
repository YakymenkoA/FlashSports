using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        // Navigation
        public virtual User User { get; set; }
        public virtual News News { get; set; }
    }
}
