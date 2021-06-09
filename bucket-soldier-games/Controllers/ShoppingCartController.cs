using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;
using bucket_soldier_games.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bucket_soldier_games.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IGameRepository drinkRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = drinkRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View("Index",shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int gameId) {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.id == gameId);

            if (selectedGame!=null) {
                _shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.id == gameId);

            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
    }
}