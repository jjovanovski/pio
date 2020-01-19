using PIO.Repositories;
using PIO.Services;
using PIO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PIO.Controllers
{
    public class QuestionController : Controller
    {
		private QuestionService _questionService;
		private AnswerService _answerService;

		public QuestionController()
		{
			_questionService = Container.QuestionService;
			_answerService = Container.AnswerService;
		}

		// GET: Question
		public ActionResult Index(int id)
        {
			var questionsViewModel = new QuestionsViewModel();
			questionsViewModel.Question = _questionService.GetQuestion(id);
			questionsViewModel.PopularAnswers = _answerService.GetPopularAnswers(id, 1, 3);

			return View(questionsViewModel);
		}
	
    }
}