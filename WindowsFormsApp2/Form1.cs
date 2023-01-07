using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Data data =new Data() ;

        public Form1() {
            InitializeComponent();
        }
        

        private void add_Click(object sender, EventArgs e)
        {
            var player = new Player(textBox1.Text, comboBox1.Text);
            player.Name = "player";
            data.add(player.player_name, comboBox1.Text);
            player.Draggable(true);
            
            this.panel2.Controls.Add(player);
            
        }


        private void import_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить как...";
            savedialog.Filter = "XML Files(*.xml)|*.xml";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                var aba = panel2.Controls.Find("player",true);
                for (int i = 0; i < aba.Length; i++)
                {
                    data.update(aba[i].Location,i);
                }
                XmlSerializer xml = new XmlSerializer(typeof(Data));
                using (FileStream fs = new FileStream(savedialog.FileName, FileMode.Create))
                {
                    xml.Serialize(fs, data);
                }
            }
            
        }
        
        private void export_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Открыть как...";
            opendialog.Filter = "XML Files(*.xml)|*.xml";
            opendialog.ShowHelp = true;
            XmlSerializer xml = new XmlSerializer(typeof(Data));
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(opendialog.FileName, FileMode.Open))
                {
                    var temp = xml.Deserialize(fs) as Data;
                    panel2.Controls.Clear();
                    foreach (var i in temp.db)
                    {
                        var player = new Player(i);
                        player.Draggable(true);
                        panel2.Controls.Add(player);
                    }
                }
            }

        }


        private void deleteAllContent(object sender, EventArgs e)
        {
            this.panel2.Controls.RemoveAt(0);
            
        }


        
    }
}