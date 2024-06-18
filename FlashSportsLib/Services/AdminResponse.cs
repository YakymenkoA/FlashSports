using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    [Serializable]
    public class AdminResponse
    {
        public string Message { get; set; }
        public List<User> Users { get; set; }
        public List<Support> Support { get; set; }
    }
}
