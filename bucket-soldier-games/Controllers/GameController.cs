using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;
using bucket_soldier_games.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bucket_soldier_games.Controllers
{
    public class GameController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
        public GameController(ICategoryRepository categoryRepository, IGameRepository gameRepository)
        {
            _categoryRepository = categoryRepository;
            _gameRepository = gameRepository;
        }

        // GET: Games
        public ActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Game> games;

            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                games = _gameRepository.Games;
            }
            else {
                if (string.Equals("SinglePlayer", _category, StringComparison.OrdinalIgnoreCase))
                {
                    games = _gameRepository.Games.Where(p => p.Category.CategoryName.Equals("SinglePlayer"));
                }
                else if (string.Equals("MultiPlayer", _category, StringComparison.OrdinalIgnoreCase))
                {
                    games = _gameRepository.Games.Where(p => p.Category.CategoryName.Equals("MultiPlayer"));
                }
                else {
                    games = _gameRepository.Games;
                }

                currentCategory = _category;
            }
            var gameListViewModel = new GameListViewModel
            {
                Games = games,
                 CurrentCategory=currentCategory
            };
            return View(gameListViewModel);

            
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Game> games;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                games = _gameRepository.Games.OrderBy(p => p.id);
            }
            else
            {
                games = _gameRepository.Games.Where(p => p.Title.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Game/List.cshtml", new GameListViewModel { Games = games, CurrentCategory = _searchString });
        }

        public ViewResult Details(int gameId)
        {
            var drink = _gameRepository.Games.FirstOrDefault(d => d.id == gameId);
            if (drink == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(drink);
        }


    }
}