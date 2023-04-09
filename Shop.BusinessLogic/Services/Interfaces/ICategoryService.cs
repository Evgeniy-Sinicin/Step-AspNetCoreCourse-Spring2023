using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetAll();

        public Category Get(string categoryName);

        public Category Create(Category category);

        public Category Update(Category category);

        public Category Delete(int categoryId);
    }
}
