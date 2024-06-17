﻿using System;
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
        private ServerRepository _serverRepo;

        public ServerMain()
        {
            InitializeComponent();
            _serverRepo = new ServerRepository(SupportChatTB, EventLogLB);
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            _serverRepo.ServerStart();
            ApplySettings(_serverRepo.Sm.ReadFontSizeSetting());
            SupportChatTB.Text += $"Admin {DateTime.Now} -> Hello everyone";
        }

        private void ServerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _serverRepo.ServerStop();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            var settings = new Settings() { FontSize = this.Font.Size};
            if(settings.ShowDialog() == DialogResult.OK)
            {
                _serverRepo.Sm.SaveFontSizeSetting(settings.FontSize);
                ApplySettings(settings.FontSize);
            }
        }

        private void ApplySettings(float fontSize)
        {
            this.Font = new Font(this.Font.FontFamily, fontSize);
            var lbWidth = EventLogLB.ClientSize.Width;
            EventLogLB.Columns[0].Width = (int)(lbWidth * 0.20);
            EventLogLB.Columns[1].Width = (int)(lbWidth * 0.20);
            EventLogLB.Columns[2].Width = (int)(lbWidth * 0.10);
            EventLogLB.Columns[3].Width = (int)(lbWidth * 0.20);
            EventLogLB.Columns[4].Width = (int)(lbWidth * 0.30);
        }
    }
}
