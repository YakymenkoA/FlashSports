using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AddCandies : Form
    {
        private int _candy;
        public AddCandies()
        {
            InitializeComponent();
            _candy = 0;
        }

        private void AddCandies_Load(object sender, EventArgs e)
        { }

        public int GetCandyAmount() => _candy;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AmountTB.Text))
            {
                try
                {
                    _candy = Convert.ToInt32(AmountTB.Text);
                    if (_candy >= 0)
                        this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Число повинно буди цілим та додатнім!");
                    AmountTB.Text = $"{0}";
                    AmountTB.Focus();
                }
            }
            else
            {
                AmountTB.Text = $"{0}";
                AmountTB.Focus();
            }
        }
    }
}
