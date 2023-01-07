using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Mime;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    [Serializable]
    class Player:UserControl
    {
        public string player_name = "0";
        public Color _color = Color.White;
        
        
        private int size = 30;
        private Font _font = new Font(FontFamily.GenericSansSerif, 11.0F, FontStyle.Bold);
        private HatchBrush _hatchStyle = new HatchBrush(HatchStyle.Horizontal, Color.Black);
        
            



        public Player()
        {
            
        }

        public Player(playXmlSerializerer data)
        {
            player_name = data.name;
            if (data.color == "blue") {
                _color = Color.RoyalBlue;
            }
            if (data.color == "red") {
                _color = Color.Firebrick;
            }

            this.Location = data.point;
        }
        
        public Player(string playerName, String colour)
        {
            player_name = playerName;
            if (colour == "blue") {
                _color = Color.RoyalBlue;
            }
            if (colour == "red") {
                _color = Color.Firebrick;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Size = new Size(size+1, size+1);
            base.OnPaint(e);
            this.BackColor = Color.FromArgb(230, _color);
            //e.Graphics.DrawEllipse(Pens.Black, x,y,size,size);
            e.Graphics.DrawString(player_name, _font, _hatchStyle,5,5 );
        }

        

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Player
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "Player";
            this.Size = new System.Drawing.Size(30, 30);
            this.ResumeLayout(false);
        }
    }
}