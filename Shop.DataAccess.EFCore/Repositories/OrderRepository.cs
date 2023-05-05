using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace Shop.DataAccess.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order Create(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
