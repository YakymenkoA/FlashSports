using Client.Services;
using FlashSportsLib.Repositories;
using FlashSportsLib.Services;
using FlashSportsLIb2.Services;
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
        private SupportRepository _supportRepo;
        public SupportResponse currentSupportInfo;

        public Login()
        {
            InitializeComponent();
            _supportRepo = new SupportRepository(LoginTB);
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
                var auth = new string[] { LoginTB.Text, Cryptographer.GetHash(PasswordTB.Text) };
                var request = new MyRequest()
                {
                    Header = "AUTH_SUPP",
                    Obj = auth,
                };
                if (_supportRepo.SendRequest(request))
                {
                    currentSupportInfo = _supportRepo.CurrentSupportInfo;
                    DialogResult = DialogResult.OK;
                }
                DialogResult = DialogResult.OK;
            }
        }
    }
}
