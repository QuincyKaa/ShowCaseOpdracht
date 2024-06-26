using ShowCaseZeeslag.Models;
using ShowCaseZeeslag.Services;

namespace TestProject
{
    [TestFixture]
    public class changeActivePlayerTests
    {
        GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new GameService();
        }


        [Test]
        public void changeActivePlayer_players_activePlayerChanged()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            Player _player2 = new Player();

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameBoard.Players.Add(_player);
            _gameBoard.Players.Add(_player2);
            _gameBoard.ActivePlayer = _player;
            _gameService.changeActivePlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.EqualTo(_player2));
        }

        [Test]
        public void changeActivePlayer_noBoard_activePlayerNotChanged()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            Player _player2 = new Player();

            //act
            _gameBoard.Players.Add(_player);
            _gameBoard.Players.Add(_player2);
            _gameBoard.ActivePlayer = _player;
            _gameService.changeActivePlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.Not.EqualTo(_player2));
        }

        [Test]
        public void changeActivePlayer_noPlayers_activePlayerNotChanged()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            Player _player2 = new Player();

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameBoard.ActivePlayer = _player;
            _gameService.changeActivePlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.Not.EqualTo(_player2));
        }

        [Test]
        public void changeActivePlayer_noActivePlayers_activePlayerNotChanged()
        {
            //arrange
            Setup();
            GameBoard _gameBoard = new(3);
            Player _player = new Player();
            Player _player2 = new Player();

            //act
            _gameService.SetGameBoard(_gameBoard);
            _gameBoard.Players.Add(_player);
            _gameBoard.Players.Add(_player2);
            _gameService.changeActivePlayer();

            //assert
            Assert.That(_gameBoard.ActivePlayer, Is.Not.EqualTo(_player2));
        }



    }
}
