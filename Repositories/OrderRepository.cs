using System;
using bucket_soldier_games.Data;
using bucket_soldier_games.Interfaces;
using bucket_soldier_games.Models;

namespace bucket_soldier_games.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    gameId = shoppingCartItem.Game.id,
                    OrderId = order.OrderId,
                    Price = (decimal)shoppingCartItem.Game.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
