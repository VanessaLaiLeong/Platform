using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plat5
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();

            this.Hide();
        }
    }
}
