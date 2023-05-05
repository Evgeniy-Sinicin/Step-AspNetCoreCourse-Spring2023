using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.DataAccessInterfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();

        public Order Create(Order order);
    }
}
