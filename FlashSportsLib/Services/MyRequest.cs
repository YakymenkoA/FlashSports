using FlashSportsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLIb2.Services
{
    [Serializable]
    public class MyRequest
    {
        public string Header { get; set; }
        public object Obj { get; set; }
    }
}
