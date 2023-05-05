using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.DataAccess.Json.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepository(List<Order> orders)
        {
            _orders = orders;
        }

        public Order Create(Order order)
        {
            _orders.Add(order);

            return order;
        }

        public List<Order> GetAll()
        {
            return _orders;
        }
    }
}
