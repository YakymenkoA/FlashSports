using System;
using System.Windows.Forms;
using Support.Repositories;


namespace Support
{
    public partial class SupportMain : Form
    {
        private SupportRepository _suppRepo;

        public SupportMain()
        {
            InitializeComponent();
            _suppRepo = new SupportRepository() { GeneralChat = GeneralChatTB, ClientChats = PendingChatLV };
        }

        private void SupportMain_Load(object sender, EventArgs e)
        {
            if(!_suppRepo.AuthSupport())
            {
                this.Close();
            }
            else
            {
                this.Text = $"Support {_suppRepo.CurrentSupportInfo.Support.SupportName}";
                UpdateChatInfo.Start();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SendBtn_Click(object sender, EventArgs e) { }

        private void StartChatBtn_Click(object sender, EventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void UpdateChatInfo_Tick(object sender, EventArgs e)
        {
            _suppRepo.GetClientChatInfos();
        }
    }
}
