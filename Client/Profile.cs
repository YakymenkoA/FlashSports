using FlashSportsLib.Models;
using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Profile : Form
    {
        private string _editName;
        private string _editEmail;
        private string _editPass;
        private string _photoPath;
        private int _candies; 

        public Profile(string name, string email, string pass, string photoPath, int candies)
        {
            InitializeComponent();
            this._candies = candies;
            this._editName = name;
            this._editEmail = email;
            this._editPass = pass;
        }

        private void AddCandyBtn_Click(object sender, EventArgs e)
        {
            var candies = new AddCandies();
            if(candies.ShowDialog() == DialogResult.OK)
            {
                _candies += candies.GetCandyAmount();
                CandyAmount.Text = $"{_candies}";
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e) => this.Close();

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTB.Text) && !string.IsNullOrWhiteSpace(EmailTB.Text))
            {
                _editName =  NameTB.Text;
                _editEmail = EmailTB.Text;
                _candies = Convert.ToInt32(_candies);
                if (!string.IsNullOrWhiteSpace(PasswordTB.Text))
                    _editPass = Cryptographer.GetHash(PasswordTB.Text);
                // ->
                this.DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Для збереження поля Імя та Почта - повинні бути заповнені");
            } 

            
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            NameTB.Text = _editName;
            EmailTB.Text = _editEmail;
            CandyAmount.Text = $"{_candies}";
            // ->
            string photoPath = (@"..\..\Data\img\" + _photoPath);
            try
            {
                var img = Image.FromFile(photoPath);
            }
            catch
            {
                photoPath = @"..\..\img\user.png";
            }
            // ->
            ClientAvatar.BackgroundImage = Image.FromFile(photoPath);
        }

        public User GetUserInfo() =>
            new User() {
                UserName = _editName,
                Email = _editEmail,
                Password = _editPass,
                Photo = _photoPath,
            };

        public int GetCandiesAmount() => _candies;

        private void ClientAvatar_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPEG; *.PNG; *.SVG; *.JPG;) | *.JPEG; *.PNG; *.SVG; *.JPG; | All files (*.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ClientAvatar.BackgroundImage = new Bitmap(ofd.FileName);
                    string filePath = @"..\..\img\" + ofd.SafeFileName;
                    if (!File.Exists(filePath))
                        File.Copy(ofd.FileName, filePath);
                    // ->
                    _photoPath = ofd.SafeFileName;
                }
                catch
                {
                    MessageBox.Show("Impossible to open file. Format is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
