using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bucket_soldier_games.Models;
using bucket_soldier_games.ViewModels;
using bucket_soldier_games.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace bucket_soldier_games.Controllers
{

   
    public class HomeController : Controller
    {



        private readonly IGameRepository _gameRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        public ViewResult Index()
        {
            GameListViewModel vm = new GameListViewModel();
            vm.Games = _gameRepository.Games;
            vm.CurrentCategory = "All Games";
            return View(vm);
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
