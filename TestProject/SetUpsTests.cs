using ShowCaseZeeslag.Models;
using ShowCaseZeeslag.Services;

namespace TestProject
{
    [TestFixture]
    public class SetUpsTests
    {
        GameService _gameService;

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService();
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void SetGameBoard_null_addedGameBoard(int size)
        {
            //arrange
            SetUp();
            GameBoard gameBoard = new GameBoard(size);

            //act
            _gameService.SetGameBoard(gameBoard);

            //assert
            if (_gameService.Board == null)
            {
                Assert.Fail();
            }
            Assert.That(gameBoard, Is.EqualTo(_gameService.Board));
        }

        [Test]
        public void chooseStartingPlayer_null_addedActivePlayer()
        {
            //arrange
            SetUp();
            GameBoard _gameBoard = new GameBoard(3);
            Player _player1 = new Player();

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameBoard.Players.Add(_player1);
            _gameService.chooseStartingPlayer();

            //assert
            if (_gameBoard.ActivePlayer.Symbol != "x")
            {
                Assert.Fail();
            }
            Assert.That(_gameBoard.ActivePlayer, Is.EqualTo(_player1));
        }

        [Test]
        public void chooseStartingPlayer_noPlayerAdded_noAddedActivePlayer()
        {
            //arrange
            SetUp();
            GameBoard _gameBoard = new GameBoard(3);
            Player _player1 = new Player();

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameService.chooseStartingPlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.EqualTo(null));
        }

        [Test]
        public void chooseStartingPlayer_noBoardAdded_noAddedActivePlayer()
        {
            //arrange
            SetUp();
            GameBoard _gameBoard = new GameBoard(3);
            Player _player1 = new Player();

            //act
            _gameService.chooseStartingPlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.EqualTo(null));
        }
    }
}