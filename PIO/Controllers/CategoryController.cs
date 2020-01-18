using PIO.Repositories;
using PIO.Services;
using PIO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIO.Controllers
{
    public class CategoryController : Controller
    {
		private ICategoryRepository _categoryRepository;
		
		private CategoryService _categoryService;

		public CategoryController()
		{
			_categoryRepository = new CategoryRepository();

			_categoryService = new CategoryService(_categoryRepository);
		}
      

        public ActionResult Index()
        {
            return View();
        }


		public ActionResult Details(int id)
		{
			var categoryViewModel = new CategoryViewModel();
			categoryViewModel.Questions = _categoryRepository.GetQuestionsSortedById(id, 1, 3);
			return View(categoryViewModel);
		}

	}
}