using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Support
{
    public partial class Settings : Form
    {
        private Image _backgroundImg;
        private string _backgroundImgPath;

        public Image BackgroundImg
        {
            get { return _backgroundImg; }
            set { _backgroundImg = value; }
        }

        public string BackgroundImgPath
        {
            get { return _backgroundImgPath; }
            set { _backgroundImgPath = value; }
        }

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_backgroundImgPath) && System.IO.File.Exists(_backgroundImgPath))
            {
                _backgroundImg = Image.FromFile(_backgroundImgPath);
                BackgroundPB.Image = _backgroundImg;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            _backgroundImg = BackgroundPB.Image;
            DialogResult = DialogResult.OK;
        }

        private void BackgroundPB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Файли зображень (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Image selectedImage = Image.FromFile(filePath);

                    BackgroundPB.Image = selectedImage;
                    _backgroundImg = selectedImage;
                    _backgroundImgPath = filePath;
                }
            }
        }
    }
}
