using System.Drawing;
using System.Net.Mime;

namespace WindowsFormsApp2
{
    public class Player
    {
        private int x;
        private int y;
        private Image img;
        private string player_name;

        public Player(int x, int y, string playerName)
        {
            this.x = x;
            this.y = y;
            player_name = playerName;
        }
    }
}