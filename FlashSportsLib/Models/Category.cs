using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Navigation
        public virtual List<SportEvent> SportEvents { get; set; }
    }
}
