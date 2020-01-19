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
        private IQuestionRepository _questionRepository;
		private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
		
        private QuestionService _questionService;

		public CategoryController()
		{
            _questionRepository = new QuestionRepository();
			_categoryRepository = new CategoryRepository();
            _userRepository = new UserRepository();

            _questionService = new QuestionService(_questionRepository, _categoryRepository, _userRepository);
		}
      

        public ActionResult Index()
        {
            return View();
        }


		public ActionResult Details(int id)
		{
			var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Questions = _questionService.GetLatestQuestionsByCategoryId(id, 1, 10);
			return View(categoryViewModel);
		}

	}
}