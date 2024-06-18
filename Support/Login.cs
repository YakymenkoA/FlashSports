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
        public string LoginDto { get; set; }
        public string PasswordDto { get; set; }

        public Login()
        {
            InitializeComponent();
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
                LoginDto = LoginTB.Text;
                PasswordDto = Cryptographer.GetHash(PasswordTB.Text);
                this.DialogResult = DialogResult.OK;
             }
        }
    }
}
