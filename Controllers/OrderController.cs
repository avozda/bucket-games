using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bucket_soldier_games.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
         {
             var items = _shoppingCart.GetShoppingCartItems();
             _shoppingCart.ShoppingCartItems = items;
             if (_shoppingCart.ShoppingCartItems.Count == 0)
             {
                 ModelState.AddModelError("", "Your card is empty, add some drinks first");
             }

             if (ModelState.IsValid)
             {
                 _orderRepository.CreateOrder(order);
                 _shoppingCart.ClearCart();
                 return RedirectToAction("CheckoutComplete");
             }

             return View(order);
         }
        [Authorize]
        public IActionResult CheckoutComplete()
         {
             ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
             return View();
         }
    }
}