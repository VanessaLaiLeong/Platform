using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Plat5
{
    public partial class Gravar : Form
    {
        int flowers = 0;
        XmlDocument doc;
        public Gravar(int flowers)
        {
            this.flowers = flowers;
            InitializeComponent();
            

        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            pn_gravar.Visible = false;

            string content = flowers.ToString();
            lbl_score.Text = content;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("leaderBoard.xml");
            XmlNodeList nodeList = doc.SelectNodes(@"Game/player");
            XmlNode node = doc.SelectSingleNode("Game"); //vai buscar o no pai
            XmlElement element = doc.CreateElement("player");
            element.SetAttribute("name", tb_name.Text);
            element.SetAttribute("score", lbl_score.Text.Trim());           

            node.AppendChild(element);

            doc.Save("leaderBoard.xml");

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.NewLineHandling = NewLineHandling.None;
            //XmlWriter writer = XmlWriter.Create("leaderBoard.xml", settings);
            //doc.Save(writer);
            //writer.Close();

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();

            this.Hide();
        }
    }
}
