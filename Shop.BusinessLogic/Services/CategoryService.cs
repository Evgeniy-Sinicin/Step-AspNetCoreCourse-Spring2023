using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.CategoryRepository;
        }

        public Category Create(Category category)
        {
            var newCategory = _categoryRepository.Create(category);
            _unitOfWork.SaveChenges();
            return newCategory;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
