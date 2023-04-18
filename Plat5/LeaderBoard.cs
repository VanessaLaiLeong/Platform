using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Plat5
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("leaderBoard.xml");

            XmlNodeList nodeList = doc.SelectNodes("/Game/player");

            lb_board.Items.Clear();

            foreach (XmlNode node in nodeList)
            {
                XmlElement element = node as XmlElement;
                lb_board.Items.Add($"Nome: {node.Attributes["name"].Value} - Pontos: {node.Attributes["points"].Value} - Data: {node.Attributes["date"].Value} ");
            }


        }

        private void lb_board_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
