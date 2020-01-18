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
		private IQuestionRepository _questionRepository;
		private ICategoryRepository _categoryRepository;
		private IUserRepository _userRepository;
		private IAnswerRepository _answerRepository;

		private QuestionService _questionService;
		private AnswerService _answerService;

		public QuestionController()
		{
			_questionRepository = new QuestionRepository();
			_categoryRepository = new CategoryRepository();
			_userRepository = new UserRepository();
			_answerRepository = new AnswerRepository();

			_questionService = new QuestionService(_questionRepository, _categoryRepository, _userRepository);
			_answerService = new AnswerService(_answerRepository, _questionRepository, _userRepository);
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