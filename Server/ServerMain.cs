using System;
using System.Drawing;
using System.Windows.Forms;
using Server.Repositories;

namespace Server
{
    public partial class ServerMain : Form
    {
        private ServerRepository _serverRepo;

        public ServerMain()
        {
            InitializeComponent();
            _serverRepo = new ServerRepository() { SuppChat = SupportChatTB, Log = EventLogLB };
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            _serverRepo.ServerStart();
            ApplySettings(_serverRepo.Sm.ReadFontSizeSetting());
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
