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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameLv1 form = new GameLv1();
            form.Show();

            this.Hide();

        }

        private void btn_rules_Click(object sender, EventArgs e)
        {
            Rules form = new Rules();
            form.Show();

            this.Hide();
        }

        private void btn_leader_board_Click(object sender, EventArgs e)
        {
            LeaderBoard form = new LeaderBoard();
            form.Show();

            this.Hide();
        }
    }
}
