using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.DataAccess.Json.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Shop.DataAccess.Json
{
    public class JsonUnitOfWork : IUnitOfWork
    {
        private const string _categoryFilePath = "categories.json";
        private const string _productsFilePath = "products.json";
        private const string _linksFilePath = "links.json";
        private const string _ordersFilePath = "orders.json";

        public JsonUnitOfWork()
        {
            var categories = new List<Category>();
            var products = new List<Product>();
            var links = new List<Link>();
            var orders = new List<Order>();

            if (File.Exists(_categoryFilePath))
            {
                var json = File.ReadAllText(_categoryFilePath);
                categories = JsonSerializer.Deserialize<List<Category>>(json);
            }

            if (File.Exists(_productsFilePath))
            {
                var json = File.ReadAllText(_productsFilePath);
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }

            if (File.Exists(_linksFilePath))
            {
                var json = File.ReadAllText(_linksFilePath);
                links = JsonSerializer.Deserialize<List<Link>>(json);
            }

            if (File.Exists(_ordersFilePath))
            {
                var json = File.ReadAllText(_ordersFilePath);
                orders = JsonSerializer.Deserialize<List<Order>>(json);
            }

            CategoryRepository = new CategoryRepository(categories);
            ProductRepository = new ProductRepository(products);
            LinkRepository = new LinkRepository(links);
            OrderRepository = new OrderRepository(orders);
        }

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ILinkRepository LinkRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public void SaveChenges()
        {
            var categories = CategoryRepository.GetAll();
            var products = ProductRepository.GetAll();
            var links = LinkRepository.GetAll();
            var orders = OrderRepository.GetAll();

            var categoriesJson = JsonSerializer.Serialize(categories);
            var productsJson = JsonSerializer.Serialize(products);
            var linksJson = JsonSerializer.Serialize(links);
            var ordersJson = JsonSerializer.Serialize(orders);

            File.WriteAllText(_categoryFilePath, categoriesJson);
            File.WriteAllText(_productsFilePath, productsJson);
            File.WriteAllText(_linksFilePath, linksJson);
            File.WriteAllText(_ordersFilePath, ordersJson);
        }
    }
}
