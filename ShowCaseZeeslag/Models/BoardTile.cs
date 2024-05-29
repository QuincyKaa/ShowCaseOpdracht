namespace ShowCaseZeeslag.Models
{
    public class BoardTile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Player? Player { get; set; } = null;

        public BoardTile(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
