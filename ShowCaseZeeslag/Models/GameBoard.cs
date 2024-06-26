namespace ShowCaseZeeslag.Models
{
    public class GameBoard
    {
        public Player? ActivePlayer { get; set; }
        public List<Player> Players { get; set; } = [];
        public List<List<BoardTile>> Tiles { get; set; } = [];
        public int Size { get; set; } = 3;
        public bool IsWin { get; set; } = false;

        public GameBoard(int size)
        {
            Size = size;
            GenerateTiles();
        }

        public void GenerateTiles()
        {
            for (int y = 0; y < Size; y++)
            {
                Tiles.Add([]);
                for (int x = 0; x < Size; x++)
                {
                    Tiles[y].Add(new BoardTile(x, y));
                }
            }
        }

        //kiez speler
        //verwissel player
        //set tile

    }
}

