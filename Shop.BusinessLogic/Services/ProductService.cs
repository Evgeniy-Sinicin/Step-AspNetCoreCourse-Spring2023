using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public List<Product> GetAll(string categoryName)
        {
            var products = _productRepository.GetAll();
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var links = _unitOfWork.LinkRepository.GetAll();

            var categoryId = categories.FirstOrDefault(category => category.Name.Equals(categoryName)).Id;
            var categoryLinks = links.Where(link => link.CategoryId == categoryId);
            var productIds = categoryLinks.Select(categoryLink => categoryLink.ProductId);
            var filteredProducts = products.Where(product => productIds.Contains(product.Id));

            return filteredProducts.ToList();
        }
    }
}
