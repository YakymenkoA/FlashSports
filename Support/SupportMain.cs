using System;
using System.Windows.Forms;
using Support.Repositories;


namespace Support
{
    public partial class SupportMain : Form
    {
        private SupportRepository _suppRepo;
        private string _selectedChat = string.Empty;

        public SupportMain()
        {
            InitializeComponent();
            _suppRepo = new SupportRepository() { GeneralChat = GeneralChatTB, ClientChats = PendingChatLV};
            
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
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }

        private void SendBtn_Click(object sender, EventArgs e) 
        {
            string mess = MessageTB.Text;
            _suppRepo.SendMess(mess);
            
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

        }

        private void UpdateChatInfo_Tick(object sender, EventArgs e)
        {
            _suppRepo.GetClientChatInfos();
            SelectLastItem();            
        }

        private void SelectLastItem()
        {
            foreach (ListViewItem item in PendingChatLV.Items)
                if (item.SubItems[1].Text == _selectedChat)
                {
                    item.Selected = true;
                    break;
                }
        }

        private void PendingChatLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PendingChatLV.SelectedIndices.Count == 0)
                _selectedChat = string.Empty;
            if (PendingChatLV.Items.Count > 0 && PendingChatLV.SelectedIndices.Count > 0 && PendingChatLV.SelectedItems[0].SubItems[1].Text != _selectedChat)
                _selectedChat = PendingChatLV.SelectedItems[0].SubItems[1].Text;
        }

        private void UpdateGeneralChat_Tick(object sender, EventArgs e)
        {
            _suppRepo.GetGeneralChat();
        }

       
    }
}
