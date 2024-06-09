﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Models
{
    [Serializable]
    public class Support
    {
        public int Id { get; set; }
        public string SupportName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }

        // Navigation
        public virtual List<Chat> Chats { get; set; }
    }
}
