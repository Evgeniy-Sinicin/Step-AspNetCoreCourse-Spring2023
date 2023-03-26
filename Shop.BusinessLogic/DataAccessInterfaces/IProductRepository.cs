using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.DataAccessInterfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();

        public Product Create(Product product);
    }
}
