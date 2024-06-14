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
    public partial class SupportChat : Form
    {
        public SupportChat()
        {
            InitializeComponent();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MessageTB.Clear();
            MessageTB.Focus();
        }
    }
}
