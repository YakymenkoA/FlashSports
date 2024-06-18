using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    [Serializable]
    public class SupportResponse
    {
        public string Message { get; set; }
        public Support Support { get; set; }
        public string SuppChat {  get; set; }

    }
}
