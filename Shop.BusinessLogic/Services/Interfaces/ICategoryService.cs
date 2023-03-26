using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetAll();

        public Category Create(Category category);
    }
}
