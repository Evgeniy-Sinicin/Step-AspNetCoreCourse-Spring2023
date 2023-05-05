using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DataAccess.EFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Category Create(Category category)
        {
            _context.Entry(category).State = EntityState.Added;

            return category;
        }

        public Category Delete(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(category => category.Id == categoryId);

            _context.Entry(category).State = EntityState.Deleted;

            return category;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category Update(Category category)
        {
            var dbCategory = _context.Categories.FirstOrDefault(category => category.Id == category.Id);

            dbCategory.ImagePath = category.ImagePath;
            dbCategory.Name = category.Name;

            _context.Entry(dbCategory).State = EntityState.Modified;

            return dbCategory;
        }
    }
}
