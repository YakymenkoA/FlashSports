using FlashSportsLib.Interfaces;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Repositories
{
    public class AdminRepository : IAdmin
    {
        public SettingsManager AdminSM { get; set; }

        public AdminRepository()
        {
            AdminSM = new SettingsManager();
        }
    }
}
