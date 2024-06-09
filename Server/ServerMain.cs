using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashSportsLIb2.Services;
using Server.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class ServerMain : Form
    {
        public ServerMain()
        {
            InitializeComponent();
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
        }

        private void ServerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
