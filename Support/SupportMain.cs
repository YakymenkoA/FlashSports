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
            _suppRepo = new SupportRepository() { GeneralChat = GeneralChatTB };
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
