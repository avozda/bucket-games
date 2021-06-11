using System;
namespace bucket_soldier_games.Models
{
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }
        public String ShoppingCartId { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        public ShoppingCartItem()
        {

        }
    }
}
