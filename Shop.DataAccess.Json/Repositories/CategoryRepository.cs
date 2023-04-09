using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

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
            var ids = _categories.Select(x => x.Id);
            var maxId = ids.Max();

            category.Id = maxId + 1;

            _categories.Add(category);

            return category;
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category Update(Category category)
        {
            var updatableCategory = _categories.FirstOrDefault(x => x.Id == category.Id);

            updatableCategory.Name = category.Name;
            updatableCategory.ImagePath = category.ImagePath;

            return updatableCategory;
        }

        public Category Delete(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);

            _categories.Remove(category);

            return category;
        }
    }
}
