using PIO.App_Start;
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
    public class HomeController : Controller
    {
        private QuestionService _questionService;

		public HomeController()
        {
            _questionService = Container.QuestionService;
		}
        
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.LatestQuestions = _questionService.GetLatestQuestions(1, 3);
            homeViewModel.LatestUnansweredQuestions = _questionService.GetLatestUnansweredQuestions(1, 3);
            homeViewModel.PopularUnansweredQuestions = _questionService.GetPopularUnansweredQuestion(1, 3);
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

		public ActionResult LatestQuestions()
		{
			var questionListsViewModel = new QuestionListsViewModel();
			questionListsViewModel.AllLatestQuestions = _questionService.GetAllLatestQuestions();
	
			return View(questionListsViewModel);
		}

		public ActionResult LatestUnansweredQuestions()
		{
			var questionListsViewModel = new QuestionListsViewModel();
			questionListsViewModel.AllLatestUnansweredQuestions = _questionService.GetAllLatestUnansweredQuestions();

			return View(questionListsViewModel);
		}

		public ActionResult PopularUnansweredQuestions()
		{
			var questionListsViewModel = new QuestionListsViewModel();
			questionListsViewModel.AllPopularUnansweredQuestions = _questionService.GetAllPopularUnansweredQuestion();

			return View(questionListsViewModel);
		}
	}
}