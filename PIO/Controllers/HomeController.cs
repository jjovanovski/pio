﻿using PIO.App_Start;
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

		public ActionResult LatestQuestions(int ?page)
		{
			var homeViewModel = new HomeViewModel();
			homeViewModel.LatestQuestions = _questionService.GetLatestQuestions((page ?? 1),3);
			ViewBag.Items = _questionService.GetAllLatestQuestions().Count;

			return View(homeViewModel);
		}

		public ActionResult LatestUnansweredQuestions(int? page)
		{
			var homeViewModel = new HomeViewModel();
			homeViewModel.LatestUnansweredQuestions = _questionService.GetLatestUnansweredQuestions((page ?? 1), 3);
			ViewBag.Items = _questionService.GetAllLatestUnansweredQuestions().Count;

			return View(homeViewModel);
		}

		public ActionResult PopularUnansweredQuestions(int? page)
		{
			var homeViewModel = new HomeViewModel();
			homeViewModel.PopularUnansweredQuestions = _questionService.GetPopularUnansweredQuestion((page ?? 1), 3);
			ViewBag.Items = _questionService.GetAllPopularUnansweredQuestion().Count;

			return View(homeViewModel);
		}
	}
}