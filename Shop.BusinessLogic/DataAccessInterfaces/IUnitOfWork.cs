namespace Shop.BusinessLogic.DataAccessInterfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ILinkRepository LinkRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public void SaveChenges();
    }
}
