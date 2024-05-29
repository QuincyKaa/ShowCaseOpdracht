using ShowCaseZeeslag.Models;

namespace ShowCaseZeeslag.Services
{
    public class GameService
    {
        private GameBoard? Board { get; set; }
        private Random Random { get; } = new Random();
        public void SetGameBoard(GameBoard gameBoard)
        {
            Board = gameBoard;
        }

        public void chooseStartingPlayer()
        {
            if (Board == null || Board.Players.Count == 0) return;
            Board.ActivePlayer = Board.Players[Random.Next(Board.Players.Count)];
            Board.ActivePlayer.Symbol = 'x';
        }

        public void changeActivePlayer()
        {
            if (Board == null || Board.Players.Count == 0 || Board.ActivePlayer == null) return;
            int currentPlayerIndex = Board.Players.IndexOf(Board.ActivePlayer);
            int NextPlayerIndex = currentPlayerIndex + 1;
            if (NextPlayerIndex == Board.Players.Count) NextPlayerIndex = 0;
            Board.ActivePlayer = Board.Players[NextPlayerIndex];
            Board.ActivePlayer.Symbol = 'o';
        }

        public void SetTile(int x, int y, Player player)
        {
            if (Board == null || player.Symbol.Equals(null)) return;
            BoardTile? tile = Board.Tiles.SelectMany(item => item).FirstOrDefault(tile => tile.X == x && tile.Y == y);
            if (tile == null || tile.Player != null) return;
            tile.Player = player;
        }

        public bool checkForWin(Player player)
        {
            if (Board == null) return false;
            List<List<BoardTile>> tiles = Board.Tiles;
            int size = Board.Size;
            if ((checkHorizontalWin(tiles, size)) || (CheckVerticalWin(tiles, size)) || (checkWinDiaganolLowToHigh(tiles, size)) || checkWinDiaganolHighToLow(tiles))
            {
                Board.IsWin = true;
                return true;
            }
            return false;
        }

        private bool checkHorizontalWin(List<List<BoardTile>> tiles, int size)
        {
            for (int y = 0; y < size; y++)
            {
                Player? firstPlayer = tiles[y].First().Player;
                if (tiles[y].All(tile => tile.Player != null && tile.Player.Equals(firstPlayer))) return true;

            }
            return false;
        }

        private bool CheckVerticalWin(List<List<BoardTile>> tiles, int size)
        {
            for (int x = 0; x < size; x++)
            {
                if (tiles[0][x].Player != null)
                {
                    bool win = true;
                    for (int rowIdx = 1; rowIdx < tiles.Count; rowIdx++)
                    {
                        if (tiles[rowIdx][x].Player != tiles[0][x].Player)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkWinDiaganolLowToHigh(List<List<BoardTile>> tiles, int size)
        {
            BoardTile firstTile = tiles[0][size - 1];
            if (firstTile.Player == null) return false;
            bool win = true;
            for (int x = 0; x < tiles.Count; x++)
            {
                int y = size - 1;
                if (tiles[x][y - x].Player != firstTile.Player)
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                return true;
            }
            return false;
        }
        private bool checkWinDiaganolHighToLow(List<List<BoardTile>> tiles)
        {
            BoardTile firstTile = tiles[0][0];
            if (firstTile.Player == null) return false;
            bool win = true;
            for (int XandY = 0; XandY < tiles.Count; XandY++)
            {
                if (tiles[XandY][XandY].Player != firstTile.Player)
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                return true;
            }
            return false;
        }




    }
}
