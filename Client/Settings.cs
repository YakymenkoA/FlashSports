using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Settings : Form
    {
        private string _fontFamily;
        public string FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        public Settings()
        {
            InitializeComponent();
            LoadFonts();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fontFamily))
            {
                FontsCB.Text = _fontFamily;
            }
        }

        private void LoadFonts()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;

            FontsCB.Items.Clear();

            foreach (FontFamily font in fontFamilies)
            {
                FontsCB.Items.Add(font.Name);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            _fontFamily = FontsCB.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
