using ShowCaseZeeslag.Models;
using ShowCaseZeeslag.Services;

namespace TestProject
{
    [TestFixture]
    public class checkForWinTests
    {
        GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new GameService();
        }

        [Test]
        [TestCase(0, 0, 0, 1, 0, 2)]
        [TestCase(0, 0, 1, 0, 2, 0)]
        [TestCase(0, 0, 1, 1, 2, 2)]
        [TestCase(2, 0, 1, 1, 0, 2)]
        public void checkForWin_coördinates_GameWon(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            _player.Symbol = "x";

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x1.ToString(), y1.ToString(), _player);
            _gameService.SetTile(x2.ToString(), y2.ToString(), _player);
            _gameService.SetTile(x3.ToString(), y3.ToString(), _player);
            _gameService.checkForWin(_player);

            //assert
            Assert.That(_gameBoard.IsWin, Is.EqualTo(true));

        }

        [Test]
        [TestCase(0, 0, 0, 1, 1, 2)]
        [TestCase(0, 0, 1, 0, 1, 0)]
        [TestCase(0, 0, 1, 0, 2, 2)]
        [TestCase(2, 0, 2, 1, 0, 2)]
        public void checkForWin_wrongCoördinates_GameNotWon(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            _player.Symbol = "x";

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.SetTile(x1.ToString(), y1.ToString(), _player);
            _gameService.SetTile(x2.ToString(), y2.ToString(), _player);
            _gameService.SetTile(x3.ToString(), y3.ToString(), _player);
            _gameService.checkForWin(_player);

            //assert
            Assert.That(_gameBoard.IsWin, Is.Not.EqualTo(true));

        }
    }
}