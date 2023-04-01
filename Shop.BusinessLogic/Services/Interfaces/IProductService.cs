using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll(string categoryName);
    }
}
