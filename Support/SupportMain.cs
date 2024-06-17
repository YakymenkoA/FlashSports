using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using FlashSportsLib.Models;
using FlashSportsLib.Repositories;
using System.Net.Http.Headers;

namespace Support
{
    public partial class SupportMain : Form
    {
        private SupportRepository _suppRepo;

        public SupportMain()
        {
            InitializeComponent();
            _suppRepo = new SupportRepository(GeneralChatTB);
        }

        private void SupportMain_Load(object sender, EventArgs e)
        {
            var auth = new Login();
            if (auth.ShowDialog() == DialogResult.OK)
            {
                //_suppRepo.ConnectSupp();
            }
            else
                this.Close();

            //_suppRepo.ConnectSupp();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SendBtn_Click(object sender, EventArgs e) { }

        private void StartChatBtn_Click(object sender, EventArgs e) { }
    }
}
