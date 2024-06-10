using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class Settings : Form
    {
        private string _backColor;
        public string BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        public Settings()
        {
            InitializeComponent();
            LoadColors();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_backColor))
                BackColorsCB.Text = _backColor;
        }

        private void LoadColors()
        {
            KnownColor[] knownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            BackColorsCB.Items.Clear();
            foreach (KnownColor knownColor in knownColors)
            {
                Color color = Color.FromKnownColor(knownColor);
                BackColorsCB.Items.Add(color.Name);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            _backColor = BackColorsCB.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
