using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShowCaseZeeslag.Models;
using ShowCaseZeeslag.Services;
using System.Diagnostics;

namespace ShowCaseZeeslag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameService _gameService;

        public HomeController(ILogger<HomeController> logger, GameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [Authorize]//geen admin
        public IActionResult Index()
        {
            GameBoard gameBoard = new(2);
            _gameService.SetGameBoard(gameBoard);
            Player player1 = new Player();
            player1.Name = "Player1";
            Player player2 = new Player();
            player2.Name = "player2";
            _gameService.Board.Players.Add(player1);
            _gameService.Board.Players.Add(player2);
            _gameService.chooseStartingPlayer();
            return View(gameBoard);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
