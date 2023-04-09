using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.DataAccessInterfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();

        public Category Create(Category category);

        public Category Update(Category category);

        public Category Delete(int categoryId);
    }
}
