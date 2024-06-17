using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Repositories;
using FlashSportsLib.Models;
using FlashSportsLib.Services;
using FlashSportsLIb2.Services;

namespace Client
{
    enum SportCategories { Football, SportType2, Soccer, SportType4 };
    public partial class ClientMain : Form
    {
        private ClientRepository _clientRepo;

        public ClientMain()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
        }

        private void SettingIcon_Click(object sender, EventArgs e)
        {
            var setting = new Settings() { FontFamily = this.Font.FontFamily.Name };
            if (setting.ShowDialog() == DialogResult.OK)
            {
                _clientRepo.ClientSM.SaveFontFamilySetting(setting.FontFamily);
                ApplySettings(setting.FontFamily);
            }
        }

        private void ApplySettings(string fontFamily)
        {
            try
            {
                FontFamily newFontFamily = new FontFamily(fontFamily);
                Font newFont = new Font(newFontFamily, this.Font.Size);
                this.Font = newFont;
            }
            catch (ArgumentException)
            {
                MessageBox.Show($"This fontFamily '{fontFamily}' is currently unavailable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClientMain_Load(object sender, EventArgs e)
        {
            // #
            ApplySettings(_clientRepo.ClientSM.ReadFontFamilySetting());

            //
            var auth = new Login();
            bool success = false;
            while (!success)
            {
                DialogResult result = auth.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _clientRepo.CurrentClientInfo = auth.currentClientInfo;
                    success = true;
                    // ->
                    UserNickname.Text = _clientRepo.CurrentClientInfo.User.UserName;
                    CandyAmount.Text += $" {_clientRepo.CurrentClientInfo.CandyAmount}";
                    // ------------------------------------------------------

                   


                }
                else if (result == DialogResult.Yes)
                {
                    var reg = new Registration();
                    DialogResult result2 = reg.ShowDialog();
                    if (result2 == DialogResult.OK)
                    {

                        success = true;
                    }
                    else
                    {
                        success = true;
                        this.Close();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    success = true;
                    this.Close();
                }
            }
        }

        private void UserAvatar_Click(object sender, EventArgs e)
        {
            var profile = new Profile();
            if (profile.ShowDialog() == DialogResult.OK) {}
        }

        private void SupportIcon_Click(object sender, EventArgs e)
        {
            var supportChat = new SupportChat();
            if (supportChat.ShowDialog() == DialogResult.OK) {}
        }

        private void FiledEvetsList(int index)
        {
            if (index > -1)
            {
                EventsLV.Items.Clear();
                switch (index) { 
                    case (int)SportCategories.Football:
                        // ...
                    break;
                    case (int)SportCategories.SportType2:
                        // ...
                        break;
                    case (int)SportCategories.Soccer:
                            foreach (var row in _clientRepo.CurrentClientInfo.SportEvents)
                            {
                                try
                                {
                                    var listItem = EventsLV.Items.Add(row.Title);
                                    listItem.SubItems.Add(row.Description);
                                    listItem.SubItems.Add(row.IssueDate.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"{ex}");
                                }
                            }
                        break;
                    case (int)SportCategories.SportType4:
                        // ...
                        break;
                    default:

                        break;
                }
            }
        }

        private void FilterTC_TabChange(object sender, EventArgs e)
        {
            //FilterTC.SelectedIndex = (int)SportCategories.Soccer;
            FiledEvetsList(FilterTC.SelectedIndex);

        }
    }
}
