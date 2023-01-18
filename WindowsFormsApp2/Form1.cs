using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Data data = new Data();

        public Form1()
        {
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


        private void export_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить как...";
            savedialog.Filter = "XML Files(*.xml)|*.xml";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                var aba = panel2.Controls.Find("player", true);
                for (int i = 0; i < aba.Length; i++)
                {
                    data.update(aba[i].Location, i);
                }

                XmlSerializer xml = new XmlSerializer(typeof(Data));
                using (FileStream fs = new FileStream(savedialog.FileName, FileMode.Create))
                {
                    xml.Serialize(fs, data);
                }
            }

        }

        private void import_Click(object sender, EventArgs e)
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
                    data = temp;
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


        private void deletelast(object sender, EventArgs e)
        {
            this.panel2.Controls.RemoveAt(panel2.Controls.Count - 1);
            data.RemoveLast();
        }
        
        private void save_image(object sender, EventArgs e)
        {
            {
                int width = panel2.Size.Width;
                int height = panel2.Size.Height;

                Bitmap bm = new Bitmap(width, height);

                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title =  "Сохранить как...";
                savedialog.Filter = "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    panel2.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                    var path = savedialog.FileName;
                    bm.Save(path, ImageFormat.Png);
                }
            }

        }
    }
}