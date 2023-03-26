using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.DataAccess.Json.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository(List<Product> products)
        {
            _products = products;
        }

        public Product Create(Product product)
        {
            _products.Add(product);

            return product;
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
