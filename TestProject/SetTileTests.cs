using ShowCaseZeeslag.Models;
using ShowCaseZeeslag.Services;

namespace TestProject
{
    [TestFixture]
    public class SetTileTests
    {
        GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new GameService();
        }


        [Test]
        public void SetTile_coördinatesAndPLayer_TileClaimedByPlayer()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            _player.Symbol = "x";
            int x_coordinate = 0;
            int y_coordinate = 2;

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player);

            //assert
            Assert.That(_gameBoard.Tiles[y_coordinate][x_coordinate].Player, Is.EqualTo(_player));
        }

        [Test]
        public void SetTile_noBoard_TileNotClaimedByPlayer()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            _player.Symbol = "x";
            int x_coordinate = 0;
            int y_coordinate = 2;

            //act
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player);

            //assert
            Assert.That(_gameBoard.Tiles[y_coordinate][x_coordinate].Player, Is.EqualTo(null));
        }

        [Test]
        public void SetTile_noPlayerSymbol_TileNotClaimedByPlayer()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            int x_coordinate = 0;
            int y_coordinate = 2;

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player);

            //assert
            Assert.That(_gameBoard.Tiles[y_coordinate][x_coordinate].Player, Is.EqualTo(null));
        }

        [Test]
        public void SetTile_AllreadyWon_TileNotClaimedByPlayer()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            _player.Symbol = "x";
            int x_coordinate = 0;
            int y_coordinate = 2;

            //act
            _gameBoard.IsWin = true;
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player);

            //assert
            Assert.That(_gameBoard.Tiles[y_coordinate][x_coordinate].Player, Is.EqualTo(null));
        }

        [Test]
        public void SetTile_AllreadyOccupied_TileNotClaimedByPlayer()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            Player _player2 = new Player();
            _player.Symbol = "x";
            _player2.Symbol = "o";
            int x_coordinate = 0;
            int y_coordinate = 2;

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player2);
            _gameService.SetTile(x_coordinate.ToString(), y_coordinate.ToString(), _player);

            //assert
            Assert.That(_gameBoard.Tiles[y_coordinate][x_coordinate].Player, Is.EqualTo(_player2));
        }

    }
}