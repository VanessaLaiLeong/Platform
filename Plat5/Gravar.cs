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
        XmlDocument doc;
        public Gravar()
        {
            InitializeComponent();
            




        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            pn_gravar.Visible = false;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "score.txt");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                lbl_score.Text = content;
                reader.Close();

                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.Write("");
                    writer.Close();
                }

            }

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gravar_Load(object sender, EventArgs e)
        {

        }
    }
}
