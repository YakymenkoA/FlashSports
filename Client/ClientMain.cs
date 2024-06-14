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

namespace Client
{
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
            if (auth.ShowDialog() == DialogResult.OK)
            {
                //...
            }
            else
                this.Close();
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
    }
}
