using System;
using System.Drawing;
using System.Windows.Forms;
using Support.Repositories;


namespace Support
{
    public partial class SupportMain : Form
    {
        private SupportRepository _suppRepo;

        public SupportMain()
        {
            InitializeComponent();
            _suppRepo = new SupportRepository() { GeneralChat = GeneralChatTB, ClientChats = PendingChatLV };
        }

        private void SupportMain_Load(object sender, EventArgs e)
        {
            if(!_suppRepo.AuthSupport())
            {
                this.Close();
            }
            else
            {
                this.Text = $"Support {_suppRepo.CurrentSupportInfo.Support.SupportName}";
                UpdateChatInfo.Start();
            }

            string backgroundImgPath = _suppRepo.SupportSM.SaveBackroundImgSetting();
            ApplySettings(backgroundImgPath);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SendBtn_Click(object sender, EventArgs e) 
        {

        }

        private void StartChatBtn_Click(object sender, EventArgs e)
        {
            if (PendingChatLV.SelectedItems.Count > 0)
            {
                var item = PendingChatLV.SelectedItems[0];
                _suppRepo.StartClientChat(item.SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("Select Chat");
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            string backgroundImgPath = _suppRepo.SupportSM.SaveBackroundImgSetting();
            var settings = new Settings() { BackgroundImgPath = backgroundImgPath };

            if (settings.ShowDialog() == DialogResult.OK)
            {
                _suppRepo.SupportSM.SaveBackColorSetting(settings.BackgroundImgPath);
                ApplySettings(settings.BackgroundImgPath);
            }
        }

        private void ApplySettings(string backgroundImgPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(backgroundImgPath) && System.IO.File.Exists(backgroundImgPath))
                {
                    Image newBackgroundImg = Image.FromFile(backgroundImgPath);
                    this.BackgroundImage = newBackgroundImg;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ви не вибрали задній фон {ex.Message}", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateChatInfo_Tick(object sender, EventArgs e)
        {
            _suppRepo.GetClientChatInfos();
        }
    }
}
