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
        private IQuestionRepository _questionRepository;

        private QuestionService _questionService;

        public HomeController()
        {
            _questionRepository = new QuestionRepository();

            _questionService = new QuestionService(_questionRepository);
        }
        
        [PassCategoryTree]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.LatestQuestions = _questionService.GetLatestQuestions(1, 20);
            homeViewModel.LatestUnansweredQuestions = _questionService.GetLatestUnansweredQuestions(1, 30);
            return View(homeViewModel);
        }

        [PassCategoryTree]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [PassCategoryTree]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}