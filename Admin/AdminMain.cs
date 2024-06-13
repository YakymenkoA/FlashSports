using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin.Repositories;

namespace Admin
{
    public partial class AdminMain : Form
    {
        private AdminRepository _adminRepo;

        public AdminMain()
        {
            InitializeComponent();
            _adminRepo = new AdminRepository();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            ApplySettings(_adminRepo.AdminSM.ReadBackColorSetting());
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            var setting = new Settings() { BackColor = this.BackColor.Name };
            if (setting.ShowDialog() == DialogResult.OK)
            {
                _adminRepo.AdminSM.SaveBackColorSetting(setting.BackColor);
                ApplySettings(setting.BackColor);
            }
        }

        private void ApplySettings(string backColorName)
        {
            try
            {
                Color newBackColor = Color.FromName(backColorName);
                this.BackColor = newBackColor;
                listView1.BackColor = newBackColor;
            }
            catch
            {
                MessageBox.Show($"This color {backColorName} is currently unavailable.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
