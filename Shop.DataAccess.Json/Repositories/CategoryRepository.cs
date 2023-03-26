using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.DataAccess.Json.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;

        public CategoryRepository(List<Category> categories)
        {
            _categories = categories;
        }

        public Category Create(Category category)
        {
            _categories.Add(category);

            return category;
        }

        public List<Category> GetAll()
        {
            return _categories;
        }
    }
}
