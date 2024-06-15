using Client.Repositories;
using Client.Services;
using FlashSportsLib.Models;
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

namespace Client
{
    public partial class Login : Form
    {
        private ClientRepository _clientRepo;
        public ClientResponse currentClientInfo;
        public Login()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            //currentUser = new User();
            _clientRepo.Connect("127.0.0.1", 9001);

        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
           
            if(string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MessageBox.Show($"Input LOGIN befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTB.Focus();
            }
            else if(string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MessageBox.Show($"Input PASSWORD befor continue! ", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTB.Focus();
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                var auth = new string[] { LoginTB.Text, Cryptographer.GetHash(PasswordTB.Text) };
                var request = new MyRequest()
                {
                    Header = "AUTH",
                    Obj = auth,
                };
                if (_clientRepo.SendRequest(request))
                {
                    currentClientInfo = _clientRepo.currentClientInfo;
                    DialogResult = DialogResult.OK;
                }
                this.Cursor = Cursor.Current;

            }

            
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            var reg = new Registration();
            DialogResult result2 = reg.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                
                this.Cursor = Cursors.WaitCursor;
                // ->
                LoginTB.Enabled = false;
                PasswordTB.Enabled = false;
                SignInBtn.Enabled = false;
                SignUpBtn.Enabled = false;
                //
                var o = new string[] { reg.name, reg.email, reg.pass};
                var request = new MyRequest()
                {
                    Header = "REG",
                    Obj = o,
                };

                _clientRepo.SendRequest(request);
                this.Cursor = Cursor.Current;
                LoginTB.Enabled = true;
                PasswordTB.Enabled = true;
                SignInBtn.Enabled = true;
                SignUpBtn.Enabled = true;
            }
            else
            {
                
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
