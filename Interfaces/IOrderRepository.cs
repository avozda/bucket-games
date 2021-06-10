using System;
using bucket_soldier_games.Models;

namespace bucket_soldier_games.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
