using FlashSportsLIb2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Interfaces
{
    internal interface ISupport
    {
        void ConnectSupp();
        bool SendRequest(MyRequest request);
    }
}
