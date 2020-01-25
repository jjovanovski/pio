using PIO.Repositories;
using PIO.Services;
using PIO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PIO.Controllers
{
    public class CategoryController : Controller
    {		
        private QuestionService _questionService;

		public CategoryController()
		{
            _questionService = Container.QuestionService;
		}
      

        public ActionResult Index()
        {
            return View();
        }


		public ActionResult Details(int id, int ?page)
		{
			var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Questions = _questionService.GetLatestQuestionsByCategoryId(id,(page ?? 1), 10);
			
			//ViewBag.Pages = pages;
			return View(categoryViewModel);
		}

	}
}