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

namespace Client
{
    enum SportCategories { Golf, Cricket, Soccer, SportType4, Bets, Favourites };
    public partial class ClientMain : Form
    {
        private ClientRepository _clientRepo;

        public ClientMain()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            _clientRepo.Connect("127.0.0.1", 9001);

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
                    DisplayEvents(_clientRepo.FilterEvents(1));
                    DisplayNews(_clientRepo.FillNews());
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
            if (profile.ShowDialog() == DialogResult.OK) { }
        }

        private void FiledEvetsList(int index)
        {
            if (index > -1)
            {
                EventsLV.Items.Clear();
                switch (index) { 
                    case (int)SportCategories.Golf:
                        {
                            DisplayEvents(_clientRepo.FilterEvents(1));
                        }
                    break;
                    case (int)SportCategories.Cricket:
                        {
                            DisplayEvents(_clientRepo.FilterEvents(2));
                        }
                        break;
                    case (int)SportCategories.Soccer:
                        {
                            DisplayEvents(_clientRepo.FilterEvents(3));                           
                        }
                        break;
                    case (int)SportCategories.SportType4:
                        {
                            // ...
                        }
                        break;
                    case (int)SportCategories.Bets:
                        {
                            // ...
                        }
                        break;
                    case (int)SportCategories.Favourites:
                        {
                            DisplayEvents(_clientRepo.FavoritesEvents());
                        }
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

        private void DisplayEvents(List<SportEvent> events)
        {
            EventsLV.Items.Clear();
            if(events.Count > 0)
            {
                foreach (var e in events)
                {
                    var listItem = EventsLV.Items.Add(e.Title);
                    listItem.SubItems.Add(e.Description);
                    listItem.SubItems.Add(e.IssueDate.ToString("g"));
                }
            }
        }

        private void BTN_AddFavorites_Click(object sender, EventArgs e)
        {

            if(EventsLV.SelectedItems.Count > 0)
            {
               
                string titleEvent = (EventsLV.SelectedItems[0].SubItems[0].Text).ToString();
                if (_clientRepo.AddToFavorite(titleEvent))
                {
                    // ...
                }
                
            }
        }
        private void DisplayNews(List<FlashSportsLib.Models.News> news)
        {
            foreach (var n in news)
            {
                NewsPanelLV.Items.Add(n.Title);
            }
        }

        private void ContactSuppL_Click(object sender, EventArgs e)
        {
            _clientRepo.ContactSupport();
        }
    }
}
