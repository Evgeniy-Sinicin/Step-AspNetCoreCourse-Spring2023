using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.DataAccess.EFCore.Repositories;

namespace Shop.DataAccess.EFCore
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;

        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private ILinkRepository _linkRepository;
        private IOrderRepository _orderRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }

                return _categoryRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository();
                }

                return _productRepository;
            }
        }

        public ILinkRepository LinkRepository
        {
            get
            {
                if (_linkRepository == null)
                {
                    _linkRepository = new LinkRepository();
                }

                return _linkRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository();
                }

                return _orderRepository;
            }
        }

        public EFUnitOfWork(ShopDbContext context)
        {
            _context = context;
        }

        public void SaveChenges()
        {
            _context.SaveChanges();
        }
    }
}
