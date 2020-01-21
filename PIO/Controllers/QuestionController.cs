using Microsoft.AspNet.Identity;
using PIO.Models.Domain;
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
        private CategoryService _categoryService;

		public QuestionController()
		{
			_questionService = Container.QuestionService;
			_answerService = Container.AnswerService;
            _categoryService = Container.CategoryService;
		}

		// GET: Question
		public ActionResult Index(int id)
        {
			var questionsViewModel = new QuestionsViewModel();
			questionsViewModel.Question = _questionService.GetQuestion(id);
			questionsViewModel.PopularAnswers = _answerService.GetPopularAnswers(id, 1, 3);

			return View(questionsViewModel);
		}

        public ActionResult Add()
        {
            var addQuestionViewModel = new AddQuestionViewModel
            {
                Categories = _categoryService.GetCategoryTree()
            };

            return View(addQuestionViewModel);
        }
        [HttpPost]
        public ActionResult Add(Question question)
        { 
            _questionService.AddQuestion(question.Title, question.Description, question.Category.Id, User.Identity.GetUserId(), DateTime.Now);
            return RedirectToAction("Index", "Question", new { id = question.Category.Id });

        }

    }
}