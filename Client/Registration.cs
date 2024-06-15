using Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Registration : Form
    {
        public string name, email, pass;
        public Registration()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            // ... 
            name = NameTB.Text; 
            email = EmailTB.Text;
            if(string.IsNullOrWhiteSpace(name)) {
                MessageBox.Show($"Input Name befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show($"Input EMAIL befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTB.Focus();
            }
            else if(string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MessageBox.Show($"Input PASSWORD befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTB2.Text))
            {
                MessageBox.Show($"Input PASSWORD - 2 befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTB2.Focus();
            }
            else if (PasswordTB.Text != PasswordTB2.Text)
            {
                MessageBox.Show($"Input PASSWORD 1 and - PASSWORD 2 is different! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTB.Clear();
                PasswordTB2.Clear();
                PasswordTB.Focus();
            }
            else
            {
                pass = Cryptographer.GetHash(PasswordTB.Text);
                DialogResult = DialogResult.OK;
            }

        }
    }
}
