using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Interfaces;
using FlashSportsLib.Services;

namespace Admin.Repositories
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
