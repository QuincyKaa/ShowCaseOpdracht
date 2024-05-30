using Microsoft.AspNetCore.SignalR;
using ShowCaseZeeslag.Services;
using System.Diagnostics;
namespace ShowCaseZeeslag.Hubs
{
    public class GameHub(GameService gameService) : Hub
    {
        private GameService _gameService = gameService;
        public async Task SetMove(string x, string y)
        {
            if (_gameService == null || _gameService.Board == null || _gameService.Board.ActivePlayer == null) return;
            _gameService.SetTile(x, y, _gameService.Board.ActivePlayer);
            await Clients.All.SendAsync("ReceiveSetMove", _gameService.Board.ActivePlayer.Symbol.ToString(), x, y);
        }
        public async Task ChangeActivePlayer()
        {
            Debug.WriteLine("testen is gelukt");
            if (_gameService == null) return;
            _gameService.changeActivePlayer();
            await Clients.All.SendAsync("UpdateTurnTile");
        }
    }
}