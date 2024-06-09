using FlashSportsLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Settings : Form
    {
        private float _fontSize;
        public float FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            FontSizeTB.Text = _fontSize.ToString();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (float.TryParse(FontSizeTB.Text, out _fontSize))
                DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Input proper value!");
                FontSizeTB.Clear();
                FontSizeTB.Focus();
            }
        }
    }
}
