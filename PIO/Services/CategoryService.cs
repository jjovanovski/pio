using PIO.Models.Domain;
using PIO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Services
{
    public class CategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository;
        }

        public ICollection<Category> GetCategoryTree()
        {
            return _categoryRepository.GetCategoryTree();
        }
    }
}