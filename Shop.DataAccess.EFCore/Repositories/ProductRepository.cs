using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace Shop.DataAccess.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
