using Support.Repositories;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Support
{
    public partial class Login : Form
    {
        private SupportRepository _suppRepo;
        public SupportResponse currentSupportInfo;

        public Login()
        {
            InitializeComponent();
            _suppRepo = new SupportRepository();
            _suppRepo.Connect("127.0.0.1", 9001);
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MessageBox.Show($"Input LOGIN before continue! ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTB.Focus();
            }
             else if (string.IsNullOrWhiteSpace(PasswordTB.Text))
             {
                 MessageBox.Show($"Input PASSWORD before continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                 PasswordTB.Focus();
             }
             else
             {
                 this.Cursor = Cursors.Default;
                 var auth = new string[] { LoginTB.Text, Cryptographer.GetHash(PasswordTB.Text) };
                 var request = new MyRequest()
                 {
                     Header = "AUTH_SUPP",
                     Obj = auth,
                 };
                 if (_suppRepo.SendRequest(request))
                 {
                     currentSupportInfo = _suppRepo.CurrentSupportInfo;
                     DialogResult = DialogResult.OK;
                 }
             }
            //this.DialogResult = DialogResult.OK;
        }
    }
}
