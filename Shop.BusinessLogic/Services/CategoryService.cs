using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Category Get(string categoryName)
        {
            var categories = _categoryRepository.GetAll();
            var category = categories.FirstOrDefault(category => category.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            return category;
        }

        public Category Update(Category category)
        {
            var updatedCategory = _categoryRepository.Update(category);

            _unitOfWork.SaveChenges();

            return updatedCategory;
        }

        public Category Delete(int categoryId)
        {
            var deletedCategory = _categoryRepository.Delete(categoryId);
            
            _unitOfWork.SaveChenges();

            return deletedCategory;
        }
    }
}
