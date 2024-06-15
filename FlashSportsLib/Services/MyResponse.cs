using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    public class MyResponse
    {
        public string Mess {  get; set; }
        public object Obj { get; set; }
        public List<object> Objects { get; set; }
    }
}
