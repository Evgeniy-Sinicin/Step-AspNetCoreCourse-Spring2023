using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = unitOfWork.ProductRepository;
        }

        public Product Create(Product product)
        {
            return _productRepository.Create(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
