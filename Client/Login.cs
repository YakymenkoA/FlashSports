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
        public User currentUser;
        public Login()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            //currentUser = new User();
            _clientRepo.Connect("127.0.0.1", 9001);

        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
           
            if(LoginTB.Text == string.Empty)
            {
                MessageBox.Show($"Input LOGIN befor continue! ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTB.Focus();
            }
            else if(PasswordTB.Text == "")
            {
                MessageBox.Show($"Input PASSWORD befor continue! ", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTB.Focus();
            }
            else
            {
                var auth = new string[] { LoginTB.Text, Cryptographer.GetHash(PasswordTB.Text) };
                var request = new MyRequest()
                {
                    Header = "AUTH",
                    Obj = auth,
                };
                if (_clientRepo.SendRequest(request))
                {
                    currentUser = _clientRepo._currentUser;
                    DialogResult = DialogResult.OK;
                }

                
            }

            
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
