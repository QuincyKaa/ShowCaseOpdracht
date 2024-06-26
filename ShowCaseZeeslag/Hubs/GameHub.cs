using Microsoft.AspNetCore.SignalR;
using ShowCaseZeeslag.Services;
namespace ShowCaseZeeslag.Hubs
{
    public class GameHub(GameService gameService) : Hub
    {
        private GameService _gameService = gameService;
        public async Task SetMove(string x, string y)
        {
            if (_gameService == null || _gameService.Board == null || _gameService.Board.ActivePlayer == null) return;
            _gameService.SetTile(x, y, _gameService.Board.ActivePlayer);
            await Clients.All.SendAsync("ReceiveSetMove", _gameService.Board.ActivePlayer.Symbol, x, y, _gameService.Board.IsWin);
        }
        public async Task ChangeActivePlayer(string test)
        {
            if (_gameService == null || _gameService.Board == null || _gameService.Board.ActivePlayer == null) return;
            _gameService.changeActivePlayer();
            await Clients.All.SendAsync("UpdateTurnTile", _gameService.Board.ActivePlayer.Symbol);
        }

        public async Task CheckForWinner(string test)
        {
            if (_gameService == null || _gameService.Board == null || _gameService.Board.ActivePlayer == null) return;
            bool win = _gameService.checkForWin(_gameService.Board.ActivePlayer);
            await Clients.All.SendAsync("CheckedForWinner", win, _gameService.Board.ActivePlayer.Symbol);
        }

    }
}